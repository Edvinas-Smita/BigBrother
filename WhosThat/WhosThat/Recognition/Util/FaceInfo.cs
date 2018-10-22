using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Face;

namespace WhosThat.Recognition.Util
{
	public class FaceInfo	//data class for showing detected faces on screen
	{
		public Rectangle faceRectangle;
		public List<Rectangle> eyeRecrangles;
		public FaceRecognizer.PredictionResult info;

		private FaceInfo(Rectangle face, List<Rectangle> eyes, FaceRecognizer.PredictionResult info = new FaceRecognizer.PredictionResult())
		{
			this.faceRectangle = face;
			this.eyeRecrangles = eyes;
			this.info = info;
		}

		public static FaceInfo FaceWithEyes(Rectangle face, Rectangle[] eyes)	//method for checking if the face has any eyes (without this i was getting faces detected randomly on the scenery behind me)
		{
			List<Rectangle> eyesWithinFace = new List<Rectangle>();
			foreach (var eye in eyes)
			{
				if (face.Contains(eye))
				{
					eyesWithinFace.Add(eye);
				}
			}

			return eyesWithinFace.Count > 0 ? new FaceInfo(face, eyesWithinFace) : null;
		}
	}
}
