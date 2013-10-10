using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.FaceRecT
{
    public class HaarCascade_ : ICascade
    {
        public Rectangle[] ObjectDetection(Bitmap probe, CascadeConfig config) 
        {
            var ImageFrame = new Image<Bgr, byte>(new Bitmap(probe));
            var grayframe = ImageFrame.Convert<Gray, byte>();

            var classifier = new CascadeClassifier(config.ClassifierXML);
            var features = classifier.DetectMultiScale(grayframe, config.ScaleIncreaseRate, config.MinNeighbors, new Size(config.MinWindowSize, config.MinWindowSize), new Size(config.MaxWindowSize, config.MaxWindowSize));

            return features;
        } 
    }
}
