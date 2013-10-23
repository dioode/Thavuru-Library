using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public interface IClassifier
    {
        Face Classify(Face probeImage, TrainingSet list, FaceAttribute faceAttribute);
    }
}
