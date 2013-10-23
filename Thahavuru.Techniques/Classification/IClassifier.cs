using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;


namespace Thahavuru.Techniques.Classification
{
    public interface IClassifier
    {
        IFace Classify(IFace probeImage, TrainingSet list, FaceAttribute faceAttribute);
    }
}
