using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using WhosThat.Recognition;
using WhosThat.Recognition.Util;

namespace WhosThat.UserManagement.Util
{
	static class UtilStatic
	{
		public static void SetupUserPicturePanel(Person user, FlowLayoutPanel panel)
		{
			RepopulatePanel(user, panel);
			//Statics.TrainSinglePersonFaces(user.Images, user.Id);   //TODO: this is just while we dont store any info anywhere
			user.Images.CollectionChanged += (sender, args) => {
				/*switch (args.Action)
				{
					case NotifyCollectionChangedAction.Add:
						Statics.TrainSinglePersonFaces(args.NewItems, user.Id);
						//train recognizer with the new images
						break;
					case NotifyCollectionChangedAction.Remove:
						//untrain(?) recognier with the removed images
						break;
					case NotifyCollectionChangedAction.Replace:
						//untrain old images and train new ones
						break;
					case NotifyCollectionChangedAction.Move:
						//do nothing with the recognizer
						break;
					case NotifyCollectionChangedAction.Reset:
						//delete (?) recognizer training for this user
						break;
				}*/
				RepopulatePanel(user, panel);
			};
		}

		private static void RepopulatePanel(Person user, FlowLayoutPanel panel) //Fills the user picture panel with the images from the user object
		{
			panel.Controls.Clear();
			int realPanelWidth = panel.Width -
								 panel.Margin.Horizontal -
								 SystemInformation.VerticalScrollBarWidth;   //width for the panel to not show the horizontal scroll bar
			for (int i = 0; i < user.Images.Count; ++i)
			{
				if (i != 0)
				{
					panel.Controls.Add(new Label()  //acts as a divisor between pictures
					{
						Text = "",
						BorderStyle = BorderStyle.Fixed3D,
						AutoSize = false,
						Height = 2,
						Width = realPanelWidth
					});
				}

				var userImage = user.Images[i];
				//	test - shows what face detector finds
				/*var userImageFull = user.Images[i];
				var userImageGray = new Image<Gray, byte>(userImageFull);
				var faceRects = EmguSingleton.Instance.FaceDetector.DetectMultiScale(userImageGray, 1.3, 5);
				var userImage = faceRects.Length > 0 ? userImageGray
					.GetSubRect(EmguSingleton.Instance.FaceDetector.DetectMultiScale(userImageGray, 1.3, 5)[0])
					.ToBitmap() : userImageFull;
				userImageGray.Dispose();*/
				//	test - shows what face detector finds

				panel.Controls.Add(new PictureBox()
				{
					Image = userImage,
					Size = new Size
					(
						realPanelWidth,
						userImage.Height * realPanelWidth / userImage.Width
					),  //picture box fitting the panel width and maintaining the picture aspect ratio
					SizeMode = PictureBoxSizeMode.Zoom
				});
			}
		}
	}
}
