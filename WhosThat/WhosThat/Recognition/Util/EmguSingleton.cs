using Emgu.CV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Face;

namespace WhosThat.Recognition.Util
{
	class EmguSingleton
	{
		public static EmguSingleton Instance = new EmguSingleton();

		public CascadeClassifier FaceDetector { get; set; }
		public CascadeClassifier EyeDetector { get; set; }

		public LBPHFaceRecognizer Recognizer { get; } = new LBPHFaceRecognizer();

		public bool SetUp(string faceHaarCascadePath, string eyeHaarCascadePath, string recognizerDataPath)
		{
			if (File.Exists(faceHaarCascadePath) && File.Exists(eyeHaarCascadePath))
			{
				FaceDetector = new CascadeClassifier(faceHaarCascadePath);
				EyeDetector = new CascadeClassifier(eyeHaarCascadePath);
				if (File.Exists(recognizerDataPath))
				{
					Recognizer.Read(recognizerDataPath);
				}

				return true;
			}

			return false;
		}
	}
}
