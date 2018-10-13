using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using WhosThat.Recognition.Util;

namespace WhosThat
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        // Cascade classifier contains data for face recognition
        private CascadeClassifier _cascadeClassifier = new CascadeClassifier(Application.StartupPath + @"\Recognition\HaarClassifiers\haarcascade_frontalface_default.xml");
		private CascadeClassifier eyeClassifier = new CascadeClassifier(Application.StartupPath + @"\Recognition\HaarClassifiers\haarcascade_eye.xml");
        private bool isCameraTab = true;
        private FaceRecognizer recognizer;
        private Image<Gray, Byte> currentFace;
        private Image<Bgr, Byte> currentFaceBgr;

        List<Person> listOfPeople = new List<Person>();

	    private ConcurrentHashSet<FaceInfo> knownFaces = new ConcurrentHashSet<FaceInfo>();
	    private static byte MAX_DETECTION_THREAD_COUNT = 16;
	    private byte currentDetectionThreadCount = 0;
		public Form1()
        {
            InitializeComponent();

			/*recognizer = new EigenFaceRecognizer();
	        _capture = new VideoCapture();
	        Application.Idle += Application_Idle;*/

			CameraThread();
			/*Thread cameraThread = new Thread(new ThreadStart(CameraThread));
			cameraThread.Start();*/
	        ThreadStart recognitionThreadStart = new ThreadStart(RecognitionThread);

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
			        finalImage.Draw(knownFace.info.Label.ToString(), knownFace.faceRectangle.Location, FontFace.HersheyTriplex, 1.0, new Bgr(Color.Green));
		        }

		        picLiveFeed.Image = finalImage.ToBitmap();
				finalImage.Dispose();
	        };
		}

        // Event is used to obtain the next frame and detect faces
        private void Application_Idle(object sender, EventArgs e)
        {

            if (_capture == null || !isCameraTab)
                return;

            if (recognizer != null && File.Exists(Application.StartupPath + @"\recognizer"))
            {
                
                recognizer.Read(Application.StartupPath + @"\recognizer");
            }
           

            using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (imageFrame == null)
                    return; 

                var result = new FaceRecognizer.PredictionResult();

                var grayframe = new Image<Gray, Byte>(imageFrame.ToBitmap());
                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.3, 5); // The actual face detection happens here
                foreach (var face in faces)
                {
                    currentFace = grayframe.Copy(face).Resize(256,256, Inter.Cubic);
                    if (recognizer != null && File.Exists(Application.StartupPath + @"\recognizer"))
                    {
                        result = recognizer.Predict(currentFace);
                        Console.WriteLine(result.Distance);
                    }


                    imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); // The detected face(s) is highlighted here using a box that is drawn around it/them
                    if (recognizer != null && File.Exists(Application.StartupPath + @"\recognizer"))
                        imageFrame.Draw(result.Label.ToString(), face.Location, FontFace.HersheyTriplex, 1.0, new Bgr(Color.Green) );
                }
                picLiveFeed.Image = imageFrame.ToBitmap();
            }
        }

        private void btnAddNewFace_Click(object sender, EventArgs e)
        {
            recognizer.Train(new [] {currentFace}, new [] {1} );
            recognizer.Write(Application.StartupPath+@"\recognizer");

            Person person = new Person(txtNewFaceName.Text,"","");
            listOfPeople.Add(person);
            cmbNames.Items.Add(person.getName());//pridedu i kameros comboboxa

            cmbNamesInProfile.Items.Add(person.getName());//pridedu i profilio comboboxa
            //gana nekoks sprendimas, reiktu listenerio gal kazkokio, bet nepamenu kaip daryt

            txtNewFaceName.Text = "";
        }


       /* public int RecognizeUser(Image userImage)
        {
           // recognizer.Read(Application.StartupPath);
            //var result = recognizer.Predict(userImage. Resize(100, 100, Inter.Cubic));
           // return result.Label;
        }*/

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            int index = listOfPeople.FindIndex(x => x.getName().Equals(cmbNamesInProfile.Text));//kolkas padariau kad programa ieskotu reikiamo objekto is comboboxe pasirinkto vardo, ne perfect
            
            listOfPeople[index].setBio(txtBio.Text);
            listOfPeople[index].setLikes(txtLikes.Text);

            txtBio.Text = "";
            txtLikes.Text = "";
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
                isCameraTab = false;
            }
            if(tabControl1.SelectedTab==tabPage1)
            {
                isCameraTab = true;
            }
        }

	    private void CameraThread()
	    {
		    var capture = new VideoCapture();
		    if (capture == null)
		    {
			    throw new ArgumentNullException("N/A", "Unable to create VideoCapture");
		    }

		    /*while (true)
		    {
				StagingSingleton.Instance.RawCameraMat = capture.QueryFrame();
			    //Thread.Sleep(1000 / 24);
		    }*/
			var mat = new Mat();
		    capture.ImageGrabbed += (a, b) =>
			{
				if (StagingSingleton.Instance.RawCameraMat != null)
				{
					capture.Retrieve(mat);	//doesnt work directly because it doesnt use the setter method and therefor doesnt cause property changed event
					StagingSingleton.Instance.RawCameraMat = mat.Clone();
				}
		    };
			capture.Start();
	    }
		
	    private void RecognitionThread()
	    {
		    long timeStart = DateTime.Now.Ticks;
			if (!isCameraTab || StagingSingleton.Instance.RawCameraMat == null)
			{
				return;
			}

			++currentDetectionThreadCount;

			if (recognizer != null && File.Exists(Application.StartupPath + @"\recognizer"))	//Is this fatal or not?
			{
				recognizer.Read(Application.StartupPath + @"\recognizer");
			}

			var result = new FaceRecognizer.PredictionResult();

			var grayframe = StagingSingleton.Instance.RawCameraMat.ToImage<Gray, Byte>();
			var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.3, 5); // The actual face detection happens here
		    var eyes = eyeClassifier.DetectMultiScale(grayframe, 1.3, 5);
			var newFaces = new ConcurrentHashSet<FaceInfo>();
			foreach (var face in faces)
			{
				currentFace = grayframe.Copy(face).Resize(256, 256, Inter.Cubic);	//Do we need to resize?
				if (recognizer != null && File.Exists(Application.StartupPath + @"\recognizer"))
				{
					result = recognizer.Predict(currentFace);
					Console.WriteLine(result.Distance);
				}
				currentFace.Dispose();
				FaceInfo.AddToSetIfValid(face, eyes, newFaces);
			}
			grayframe.Dispose();
			
			knownFaces = newFaces;

			//Console.WriteLine("Face count: {0}, time: {1}ms", newFaces.Count, (DateTime.Now.Ticks - timeStart) / 10000);
			--currentDetectionThreadCount;
		}
    }
}
