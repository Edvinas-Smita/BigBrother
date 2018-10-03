using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        private VideoCapture _capture;
        // Cascade classifier contains data for face recognition
        private CascadeClassifier _cascadeClassifier = new CascadeClassifier(Application.StartupPath + @"\Recognition\HaarClassifiers\haarcascade_frontalcatface_extended.xml");
        private bool isCameraTab = true;
        private FaceRecognizer recognizer;
        private Image<Gray, Byte> currentFace;
        private Image<Bgr, Byte> currentFaceBgr;

        List<Person> listOfPeople = new List<Person>();
        public Form1()
        {
            InitializeComponent();
            recognizer = new EigenFaceRecognizer();
            _capture = new VideoCapture();
            Application.Idle += Application_Idle;
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
                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.02, 10, Size.Empty); // The actual face detection happens here
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
    }
}
