using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace WhosThat
{
    public partial class Form1 : Form
    {
        private VideoCapture Webcam { get; set; }
        private EigenFaceRecognizer FaceRecognition { get; set; }
        private CascadeClassifier FaceDetection { get; set; }
        private CascadeClassifier EyeDetection { get; set; }
        private Mat Frame { get; set; }
        private List<Image<Gray, byte>> Faces { get; set; }
        private List<int> IDs { get; set; }
        private int ProcessedImageWidth { get; set; } = 128;
        private int ProcessedImageHeight { get; set; } = 150;
        private int TimerCounter { get; set; } = 0;
        private int TimeLimit { get; set; } = 40;
        private int ScanCounter { get; set; } = 0;

        private string YMLPath { get; set; } = Application.StartupPath +
                                              @"\Recognition\trainingData.yml";
        private Timer Timer { get; set; }
        private bool FaceSquare { get; set; } = true;
        private bool EyeSquare { get; set; } = true;
        private const int _threshold = 3750;

        private int idToRemember;

        private bool isCameraTab = true;

        private MouseEventArgs _removeMe;

        List<Person> listOfPeople = new List<Person>();

        List<Person> currentPeople = new List<Person>();

        public Form1()
        {
            InitializeComponent();

            FaceRecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);

            if (File.Exists(YMLPath) && new FileInfo(YMLPath).Length > 0)
            {
                FaceRecognition.Read(YMLPath);
            }
            FaceDetection = new CascadeClassifier(Application.StartupPath +
                                                  @"\Recognition\HaarClassifiers\haarcascade_frontalface_default.xml");
            
            EyeDetection = new CascadeClassifier(Application.StartupPath +
                                                 @"\Recognition\HaarClassifiers\haarcascade_eye.xml");
            Frame = new Mat();
            Faces = new List<Image<Gray, byte>>();
            IDs = new List<int>();
            InitWebcam();
        }

        private void InitWebcam()
        {
            if (Webcam == null)
                Webcam = new VideoCapture();

            Webcam.ImageGrabbed += Webcam_ImageGrabbed;
            Webcam.Start();

        }


        private void Webcam_ImageGrabbed(object sender, EventArgs e)
        {
            currentPeople = new List<Person>();

            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Bgr, byte>();

            if (imageFrame != null)
            {
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.3, 5);
                //var eyes = EyeDetection.DetectMultiScale(grayFrame, 1.3, 5);

                if (FaceSquare && faces.Count() != 0)
                {
                    foreach (var face in faces)
                    {
                        var processedImage = grayFrame.Copy(face).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        try
                        {
                            var result = FaceRecognition.Predict(processedImage);
                            var label = CheckRecognizeResults(result, _threshold);
                            imageFrame.Draw(label, face.Location, FontFace.HersheyTriplex, 1.0, new Bgr(Color.Chartreuse));
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Message: "+ex.Message+" Data: "+ex.Data);
                        }
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);
                    }
                }
                /*if (EyeSquare)
                {
                    foreach (var eye in eyes)
                    {
                        imageFrame.Draw(eye, new Bgr(Color.Yellow), 3);
                    }
                }*/
                picLiveFeed.Image = imageFrame.ToBitmap();
            }
        }

        private void btnAddNewFace_Click(object sender, EventArgs e)
        {
            if (txtNewFaceName.Text != string.Empty && int.TryParse(txtNewFaceName.Text, out int id))
            {
                idToRemember = id;

                Console.Write($"Training has started. {Environment.NewLine}");
                Console.WriteLine("Person id is: "+ txtNewFaceName.Text);
                txtNewFaceName.Enabled = !txtNewFaceName.Enabled;

                Timer = new Timer();
                Timer.Interval = 300;
                Timer.Tick += Timer_Tick;
                Timer.Start();
                btnAddNewFace.Enabled = !btnAddNewFace.Enabled;
            }

            Person person = new Person(txtNewFaceName.Text, "", "");
            listOfPeople.Add(person);
            cmbNames.Items.Add(person.getName()); //pridedu i kameros comboboxa

            cmbNamesInProfile.Items.Add(person.getName()); //pridedu i profilio comboboxa
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            //System.Diagnostics.Debug.WriteLine(TimerCounter);

            if (TimerCounter < TimeLimit)
            {
                TimerCounter++;

                if (imageFrame != null)
                {
                    var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);
                    
                    if (faces.Count() > 0)
                    {
                        var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight,
                            Emgu.CV.CvEnum.Inter.Cubic);
                        Faces.Add(processedImage);
                        IDs.Add(int.Parse(txtNewFaceName.Text));
                        Console.WriteLine("ID: "+IDs[IDs.Count-1]);

                        ScanCounter++;
                        Console.WriteLine($"{ScanCounter} Successful Scans Taken...");
                       
                    }
                }
            }
            else
            {
                if (Faces.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("ADDED FACE IMAGES FOR TRAINING: " + Faces.ToArray().Length + '\n');
                    System.Diagnostics.Debug.WriteLine("IDs array length " + IDs.ToArray().Length);
                    FaceRecognition.Train(Faces.ToArray(), IDs.ToArray());
                }
                EndTraining(Faces.Count > 0);
            }
        }


        private void EndTraining(bool facesDetected)
        {
            FaceRecognition.Write(YMLPath);
            Timer.Stop();
            TimerCounter = 0;
            btnAddNewFace.Enabled = !btnAddNewFace.Enabled;
            txtNewFaceName.Enabled = !txtNewFaceName.Enabled;
            Console.Write($"Training Complete! {Environment.NewLine}");
            if (!facesDetected)
            {
                Console.WriteLine("ERROR: No faces detected during training.");
                MessageBox.Show("Error: No faces detected during training.");
                return;
            }
            MessageBox.Show("Training complete!");
        }

        public int RecognizeUser(Image<Bgr, Byte> userImage)
        {
            FaceRecognition.Read(Application.StartupPath);
            var result = FaceRecognition.Predict(userImage.Resize(100, 100, Inter.Cubic));
            return result.Label;
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            int index = listOfPeople.FindIndex(x => x.getName().Equals(cmbNamesInProfile.Text));//kolkas padariau kad programa ieskotu reikiamo objekto is comboboxe pasirinkto vardo, ne perfect
            
            listOfPeople[index].setBio(txtBio.Text);
            listOfPeople[index].setLikes(txtLikes.Text);

            txtBio.Text = "";
            txtLikes.Text = "";
        }


        private void recognizeButton_Click(object sender, EventArgs e)
        { 
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
                        //Console.WriteLine("No faces trained, can't recognize");
                    }
                }
                else
                {
                    //Console.WriteLine("No faces found");
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

            return EigenLabel;// + '\n' + "Distance: " + EigenDistance.ToString();

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
                Webcam.Stop();
            }
            if(tabControl1.SelectedTab==tabPage1)
            {
                //isCameraTab = true;
                Webcam.Start();
            }
        }
    }
}
