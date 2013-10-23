using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.ViewModels;
using Thahavuru.Techniques.ClassificationT;

namespace Thahavuru.Techniques.Classification
{
    public class SVMClassifier : IClassifier
    {
        public Face Classify(Face probeImage, TrainingSet list, FaceAttribute faceAttribute)
        {
            SVMT svm = new SVMT();
            var result = svm.SVMTT(probeImage, list);
            if (faceAttribute.IsBinary)
            {
                faceAttribute.SortedClasses.Add(result == 1 ? 2 : 1);
            }
            probeImage.FaceAttributes.Add(faceAttribute);
            return probeImage;
        }
    }
}
