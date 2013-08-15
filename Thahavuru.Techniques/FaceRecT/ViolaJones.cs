using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;

namespace Thahavuru.Techniques.FaceRecT
{
    public class ViolaJones
    {
        private HaarCascade haarCascade;

        /// <summary>
        /// Identify face image nose and mouth, eyes
        /// </summary>
        /// <param name="probeImage"></param>
        public void GetFeatures(Bitmap probeImage) 
        {
            haarCascade = new HaarCascade(@"haarcascade_frontalface_alt_tree.xml");
            Image<Gray, Byte> grayFrame = new Image<Gray, Byte>(probeImage);

            var detectedFaces = grayFrame.DetectHaarCascade(haarCascade)[0];

            foreach (var face in detectedFaces)
                face.rect.

            image1.Source = ToBitmapSource(currentFrame);
        }
    }
}
