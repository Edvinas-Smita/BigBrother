using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using WhosThat.Recognition.Util;

namespace WhosThat
{
	public partial class AddFaceForm : Form
	{
		public AddFaceForm(ConcurrentHashSet<FaceInfo> faces, Image<Bgr, byte> img)	//far from being implimented - this should show up when there is more than one face in either the image from the file or camera
		{
			InitializeComponent();
			List<PictureBox> list = new List<PictureBox>();
			for (int i = 0; i < 5; i++)
			{
				foreach (var face in faces)
				{
					var pictureBox = new PictureBox();
					pictureBox.Image = img.Copy(face.faceRectangle).ToBitmap();
					pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
					pictureBox.MouseClick += (a, b) =>
					{
						foreach (var box in list)
						{
							box.BorderStyle = BorderStyle.None;
						}
						pictureBox.BorderStyle = BorderStyle.FixedSingle;
					};
					imagePanel.Controls.Add(pictureBox);
				}
			}
		}
	}
}
