using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using BigBrother.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OpenCvSharp;
using Xamarin.Forms.Internals;

namespace BigBrother.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecognitionPage : ContentPage
	{
		private VideoCapture capture = null;
		private RecognitionViewModel viewModel = new RecognitionViewModel();
		public RecognitionPage ()
		{
			InitializeComponent ();
			
			mainImage.BindingContext = viewModel;
			
			try
			{
				if (File.Exists(@"DeltaHeavy_WhiteFlag.mp4"))	//Video capture from file (only works for UWPx86)
				{
					capture = new VideoCapture(@"DeltaHeavy_WhiteFlag.mp4");
				}
				else
				{
					Debug.WriteLine(Directory.GetCurrentDirectory() + @"\DeltaHeavy_WhiteFlag.mp4 - File not found!");
				}

				/*capture = new VideoCapture(-1);	//Video capture from camera (not working)
				capture.Fps = 30;
				capture.FrameWidth = 480;
				capture.FrameHeight = 360;*/

				if (capture != null && capture.IsOpened())
				{
					Timer timer = new Timer(1000 / capture.Fps);
					timer.Elapsed += DoStuff;
					timer.AutoReset = true;
					timer.Start();
				}
				else
				{
					Debug.WriteLine("Something went wrong :(");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private void DoStuff(object sender, EventArgs args)
		{
			Mat mat = new Mat();
			if (capture.Read(mat))	//getting next frame from capture
			{
				viewModel.SetSourceFromMat(mat);	//updating image from mat
			}
		}
	}
}