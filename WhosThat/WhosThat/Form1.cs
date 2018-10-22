using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using WhosThat.Recognition;
using WhosThat.Recognition.Util;
using WhosThat.UserManagement.Util;

namespace WhosThat
{
    public partial class Form1 : Form
    {
        /*private VideoCapture _capture;
        // Cascade classifier contains data for face recognition
        //private CascadeClassifier _cascadeClassifier = new CascadeClassifier(Application.StartupPath + @"\Recognition\HaarClassifiers\lbpcascade_frontalcatface.xml");
        private CascadeClassifier _cascadeClassifier = new CascadeClassifier(Application.StartupPath + @"\Recognition\HaarClassifiers\haarcascade_frontalcatface_extended.xml");
        
        private FaceRecognizer recognizer;
        private Image<Gray, Byte> currentFace;
        private Image<Bgr, Byte> currentFaceBgr;*/


        public VideoCapture Webcam { get; set; }
        public EigenFaceRecognizer FaceRecognition { get; set; }
        public CascadeClassifier FaceDetection { get; set; }
        public CascadeClassifier EyeDetection { get; set; }
        public Mat Frame { get; set; }
        public List<Image<Gray, byte>> Faces { get; set; }
        public List<int> IDs { get; set; }
        public int ProcessedImageWidth { get; set; } = 128;
        public int ProcessedImageHeight { get; set; } = 150;
        public int TimerCounter { get; set; } = 0;
        public int TimeLimit { get; set; } = 40;
        public int ScanCounter { get; set; } = 0;
        public string YMLPath { get; set; } = Application.StartupPath +
                                              @"\Recognition\HaarClassifiers\trainingData.yml";
        public bool FaceSquare { get; set; } = true;
        public bool EyeSquare { get; set; } = true;
        private const int _threshold = 3750;

        private bool isCameraTab = true;

        private MouseEventArgs _removeMe;

        List<Person> listOfPeople = new List<Person>();

	    private static string FaceHaarCascadePath = @"Recognition\HaarClassifiers\haarcascade_frontalface_default.xml";
	    private static string EyeHaarCascadePath = @"Recognition\HaarClassifiers\haarcascade_eye.xml";
	    private static string DetectorDataPath = @"TEST.xml";

		private Person loggedInUser;

	    private ConcurrentHashSet<FaceInfo> knownFaces = new ConcurrentHashSet<FaceInfo>();
	    private static byte MAX_DETECTION_THREAD_COUNT = 16;	//otherwise it would create new thread every frame
	    private byte currentDetectionThreadCount = 0;
		public Form1()
        {
            InitializeComponent();

	        EmguSingleton.Instance.SetUp
	        (
		        FaceHaarCascadePath,
		        EyeHaarCascadePath,
				DetectorDataPath
			);
			
			//	TEST DATA
	        Storage.People.Add(Test.TestUser.CreateTestPerson("BC"));
	        Storage.People.Add(Test.TestUser.CreateTestPerson("DJ"));
	        Storage.People.Add(Test.TestUser.CreateTestPerson("DT"));
	        Storage.People.Add(Test.TestUser.CreateTestPerson(""));
	        loggedInUser = Storage.People[3];
			//	TEST DATA
	        userBioTextBox.DataBindings.Add(new Binding("Text", loggedInUser, "Bio"));
	        userLikesTextBox.DataBindings.Add(new Binding("Text", loggedInUser, "Likes"));
	        UtilStatic.SetupUserPicturePanel(loggedInUser, userPicturePanel);

			userDebugNameCombo.DataSource = new BindingSource(Storage.People, "");
	        userDebugNameCombo.DisplayMember = "Name";
	        userDebugNameCombo.SelectionChangeCommitted += (IChannelSender, args) =>
	        {
		        loggedInUser = (Person) userDebugNameCombo.SelectedItem;
				userBioTextBox.DataBindings.Clear();
		        userBioTextBox.DataBindings.Add(new Binding("Text", loggedInUser, "Bio"));
		        userLikesTextBox.DataBindings.Clear();
				userLikesTextBox.DataBindings.Add(new Binding("Text", loggedInUser, "Likes"));
				UtilStatic.SetupUserPicturePanel(loggedInUser, userPicturePanel);
			};

			ThreadStart recognitionThreadStart = new ThreadStart(DetectionThread);

	        StagingSingleton.Instance.PropertyChanged += (sender, args) =>	//executed whenever a new frame is retrieved TODO: move to seperate function
	        {
		        if (currentDetectionThreadCount < MAX_DETECTION_THREAD_COUNT)
		        {
			        new Thread(recognitionThreadStart).Start();
		        }

		        var finalImage = StagingSingleton.Instance.RawCameraMat.ToImage<Bgr, byte>();

		        foreach (var knownFace in knownFaces)
		        {
			        //all faces are bounded
			        finalImage.Draw(knownFace.faceRectangle, new Bgr(Color.BurlyWood), 3);
			        foreach (var knownFaceEyeRecrangle in knownFace.eyeRecrangles)
			        {
				        finalImage.Draw(knownFaceEyeRecrangle, new Bgr(Color.Aqua), 2);
			        }
			        //all known faces are labeled
			        finalImage.Draw(Storage.findPersonByID(knownFace.info.Label).Name, knownFace.faceRectangle.Location, FontFace.HersheyTriplex, 1.0, new Bgr(Color.Green));
		        }

		        picLiveFeed.Image = finalImage.ToBitmap();
				finalImage.Dispose();
	        };

            FaceRecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);
            //FaceDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Algo/haarcascade_frontalface_default.xml"));
            FaceDetection = new CascadeClassifier(Application.StartupPath +
                                                  @"\Recognition\HaarClassifiers\haarcascade_frontalface_default.xml");
            //EyeDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Algo/haarcascade_eye.xml"));
            EyeDetection = new CascadeClassifier(Application.StartupPath +
                                                 @"\Recognition\HaarClassifiers\haarcascade_eye.xml");
            Frame = new Mat();
            Faces = new List<Image<Gray, byte>>();
            IDs = new List<int>();
            InitWebcam();
	        Application.ApplicationExit += (sender, args) => {
		        if (Webcam != null)
		        {
			        Webcam.Stop();
		        }
	        };
        }


        private void InitWebcam()
        {
            if (Webcam == null)
            {
	            Webcam = new VideoCapture();
            }

	        var mat = new Mat();
	        Webcam.ImageGrabbed += (a, b) =>
	        {
		        if (StagingSingleton.Instance.RawCameraMat != null)
		        {
			        Webcam.Retrieve(mat);  //doesnt work directly because it doesnt use the setter method and therefor doesnt cause property changed event
			        StagingSingleton.Instance.RawCameraMat = mat.Clone();
		        }
	        };
            Webcam.Start();

			//OutputBox.AppendText($"Webcam Started...{Environment.NewLine}");
        }

        private void btnAddNewFace_Click(object sender, EventArgs e)
        {
	        var addFaceForm = new AddFaceForm(knownFaces, StagingSingleton.Instance.RawCameraMat.ToImage<Bgr, byte>());
	        addFaceForm.Show();
            /*if (txtNewFaceName.Text != string.Empty)
            {
                Console.Write($"Training has started. {Environment.NewLine}");
                txtNewFaceName.Enabled = !txtNewFaceName.Enabled;

                Timer = new Timer();
                Timer.Interval = 300;
                Timer.Tick += Timer_Tick;
                Timer.Start();
                btnAddNewFace.Enabled = !btnAddNewFace.Enabled;
            }


            /*recognizer.Train(new [] {currentFace}, new [] {Convert.ToInt32(txtNewFaceName.Text) } );
            recognizer.Write(Application.StartupPath+@"\recognizer");#1#

            Person person = new Person(txtNewFaceName.Text, "", "");
            listOfPeople.Add(person);
            cmbNames.Items.Add(person.getName()); //pridedu i kameros comboboxa

            cmbNamesInProfile.Items.Add(person.getName()); //pridedu i profilio comboboxa
            //gana nekoks sprendimas, reiktu listenerio gal kazkokio, bet nepamenu kaip daryt

            txtNewFaceName.Text = "";*/
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            System.Diagnostics.Debug.WriteLine(TimerCounter);

            if (TimerCounter < TimeLimit)
            {
                TimerCounter++;

                if (imageFrame != null)
                {
                    var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);
                    //MessageBox.Show(faces.Count().ToString());
                    if (faces.Count() > 0)                      // linq
                    {
                        var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        Faces.Add(processedImage);
                        if (Int32.TryParse(txtNewFaceName.Text, out int idResult))
                        {
                            
                        }
                        IDs.Add(idResult);
                        ScanCounter++;
                        Console.Write($"{ScanCounter} Successful Scans Taken...{Environment.NewLine}");
                        //OutputBox.ScrollToCaret();
                    }
                }
            }
            else
            {
                if (Faces.Count > 0)                                                // should we use try catcth instead?
                {
                    System.Diagnostics.Debug.WriteLine("ADDED FACE IMAGES FOR TRAINING: " + Faces.ToArray().Length + '\n');
                    FaceRecognition.Train(Faces.ToArray(), IDs.ToArray());
                }
                EndTraining(Faces.Count > 0);
            }
        }


        private void EndTraining(bool facesDetected)
        {
            FaceRecognition.Write(YMLPath);
            //Timer.Stop();
            TimerCounter = 0;
            btnAddNewFace.Enabled = !btnAddNewFace.Enabled;
            txtNewFaceName.Enabled = !txtNewFaceName.Enabled;
            Console.Write($"Training Complete! {Environment.NewLine}");
            if (!facesDetected)
            {
                Console.Write($"ERROR: No faces detected during training.{Environment.NewLine}");
                MessageBox.Show("Error: No faces detected during training.");
                return;
            }
            MessageBox.Show("Training complete!");
        }

        /*public int RecognizeUser(Image userImage)
        {
           // recognizer.Read(Application.StartupPath);
            //var result = recognizer.Predict(userImage. Resize(100, 100, Inter.Cubic));
           // return result.Label;
        }*/

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            int index = listOfPeople.FindIndex(x => x.getName().Equals(userDebugNameCombo.Text));//kolkas padariau kad programa ieskotu reikiamo objekto is comboboxe pasirinkto vardo, ne perfect
            
            listOfPeople[index].setBio(userBioTextBox.Text);
            listOfPeople[index].setLikes(userLikesTextBox.Text);

            userBioTextBox.Text = "";
            userLikesTextBox.Text = "";
        }


        private void recognizeButton_Click(object sender, EventArgs e)
        {
            /*
            Image hardcodedFb = Image.FromFile(@"C:\Users\ferN\Downloads\29694782_1889732117744398_5234807235305013248_o.jpg");

            Bitmap bmpImage = (Bitmap)hardcodedFb;
            var imageFrame = new Image<Gray, byte>(bmpImage); */


            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            if (imageFrame != null)
            {
                var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);
                Console.WriteLine($"Faces detected: {faces.Count()}");
                if (faces.Count() != 0)
                {
                    var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                    try
                    {
                        var result = FaceRecognition.Predict(processedImage);
                        Console.WriteLine(CheckRecognizeResults(result, _threshold));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No faces trained, can't recognize");
                    }

                }
                else
                {
                    Console.WriteLine("No faces found");
                }
            }
        }

        private string CheckRecognizeResults(FaceRecognizer.PredictionResult result, int threshold)
        {
            // @param threshold should usually be in [0, 5000]
            string EigenLabel;
            float EigenDistance = -1;
            if (result.Label == -1)
            {
                EigenLabel = "Unknown";
                EigenDistance = 0;
            }
            else
            {
                EigenLabel = result.Label.ToString();
                EigenDistance = (float)result.Distance;
                EigenLabel = EigenDistance > threshold ? "Unknown" : result.Label.ToString();
            }
            return EigenLabel + '\n' + "Distance: " + EigenDistance.ToString();
        }


        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            int index = listOfPeople.FindIndex(x => x.getName().Equals(cmbNames.Text));//kolkas padariau kad programa ieskotu reikiamo objekto is comboboxe pasirinkto vardo, ne perfect
            
            lblInfoAboutName.Text = "Aprašymas: " + listOfPeople[index].getBio() + Environment.NewLine + "Pomėgiai: " + listOfPeople[index].getLikes();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab==tabPage2)
            {
	            //isCameraTab = false;
	            if (Webcam != null)
	            {
		            Webcam.Stop();
	            }
            }
            if(tabControl1.SelectedTab==tabPage1)
            {
	            //isCameraTab = true;
	            if (Webcam != null)
	            {
		            Webcam.Start();
	            }
            }
        }
		
	    private void DetectionThread()
	    {
			if (!isCameraTab || StagingSingleton.Instance.RawCameraMat == null)
			{
				return;
			}
		    //long timeStart = DateTime.Now.Ticks;
			++currentDetectionThreadCount;

		    try
		    {
			    var grayframe = StagingSingleton.Instance.RawCameraMat.ToImage<Gray, Byte>();
			    var faces = EmguSingleton.Instance.FaceDetector.DetectMultiScale(grayframe, 1.3, 5);	//The actual face detection happens here
			    var eyes = EmguSingleton.Instance.EyeDetector.DetectMultiScale(grayframe, 1.3, 5);

			    var newFaces = new ConcurrentHashSet<FaceInfo>();
			    foreach (var face in faces)
			    {
				    var faceInfo = FaceInfo.FaceWithEyes(face, eyes);	//returns null if face rectangle has no eye rectangles within
					if (faceInfo != null)
					{
						faceInfo.info = EmguSingleton.Instance.Recognizer.Predict(grayframe.GetSubRect(face));
						Console.WriteLine(faceInfo.info.Distance);
						newFaces.Add(faceInfo);
					}
				}
			    grayframe.Dispose();

				knownFaces = newFaces;
		    }
		    catch (Exception e)
		    {
			    Console.WriteLine(e);
		    }

			//Console.WriteLine("Face count: {0}, detection time: {1}ms", newFaces.Count, (DateTime.Now.Ticks - timeStart) / 10000);
			--currentDetectionThreadCount;
		}

		private void userAddPic_Click(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;	//TODO: add ability to choose multiple files
			openFileDialog.Title = "Pasirinkite nuotrauką";
			openFileDialog.Filter = "Image files|*.jpg;*.png";	//TODO: more image file extensions
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					loggedInUser.Images.Add(new Bitmap(openFileDialog.FileName));
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			EmguSingleton.Instance.Recognizer.Write(DetectorDataPath);
		}
	}
}
