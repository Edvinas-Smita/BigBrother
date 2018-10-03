using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using OpenCvSharp;
using Xamarin.Forms;

namespace BigBrother.ViewModels
{
    class RecognitionViewModel : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged = delegate { };

	    private ImageSource imgSource;

	    public ImageSource ImgSource
	    {
		    get { return imgSource; }
		    set
		    {
			    imgSource = value;
			    PropertyChanged(this, new PropertyChangedEventArgs("ImgSource"));
		    }
	    }

	    public void SetSourceFromMat(Mat mat)
		{
			if (mat == null || mat.Cols == 0 || mat.Rows == 0)
			{
				return;
			}
			try
			{
				ImgSource = ImageSource.FromStream(() => new MemoryStream(mat.ToBytes()));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
    }
}
