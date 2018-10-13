using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Face;

namespace WhosThat.Recognition.Util
{
	class FaceInfo
	{
		public readonly Rectangle faceRectangle;
		public readonly List<Rectangle> eyeRecrangles;
		public readonly FaceRecognizer.PredictionResult info;

		private FaceInfo(Rectangle face, List<Rectangle> eyes, FaceRecognizer.PredictionResult info = new FaceRecognizer.PredictionResult())
		{
			this.faceRectangle = face;
			this.eyeRecrangles = eyes;
			this.info = info;
		}

		public static void AddToSetIfValid(Rectangle face, Rectangle[] eyes, ConcurrentHashSet<FaceInfo> set)
		{
			List<Rectangle> eyesWithinFace = new List<Rectangle>();
			foreach (var eye in eyes)
			{
				if (face.Contains(eye))
				{
					eyesWithinFace.Add(eye);
				}
			}

			if (eyesWithinFace.Count > 0)
			{
				set.Add(new FaceInfo(face, eyesWithinFace));
			}
		}
	}
}
