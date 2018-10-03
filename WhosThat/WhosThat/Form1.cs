﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WhosThat
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        // Cascade classifier contains data for face recognition
        private CascadeClassifier _cascadeClassifier = new CascadeClassifier(Application.StartupPath + @"\Recognition\HaarClassifiers\haarcascade_frontalcatface_extended.xml");
        private bool isCameraTab = true;

        List<Person> listOfPeople = new List<Person>();
        public Form1()
        {
            InitializeComponent();
            _capture = new VideoCapture();
            Application.Idle += Application_Idle;
        }

        // Event is used to obtain the next frame and detect faces
        private void Application_Idle(object sender, EventArgs e)
        {
            if (_capture == null || !isCameraTab)
                return;
            using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (imageFrame == null)
                    return;

                var grayframe = new Image<Gray, Byte>(imageFrame.ToBitmap());
                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.05, 5, Size.Empty); // The actual face detection happens here
                foreach (var face in faces)
                {
                    imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); // The detected face(s) is highlighted here using a box that is drawn around it/them

                }
                picLiveFeed.Image = imageFrame.ToBitmap();
            }
        }

        private void btnAddNewFace_Click(object sender, EventArgs e)
        {
            Person person = new Person(txtNewFaceName.Text,"","");
            listOfPeople.Add(person);
            cmbNames.Items.Add(person.getName());//pridedu i kameros comboboxa

            cmbNamesInProfile.Items.Add(person.getName());//pridedu i profilio comboboxa
            //gana nekoks sprendimas, reiktu listenerio gal kazkokio, bet nepamenu kaip daryt

            txtNewFaceName.Text = "";
        }

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
