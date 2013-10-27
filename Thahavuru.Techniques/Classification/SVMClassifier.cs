using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.ClassificationT;

namespace Thahavuru.Techniques.Classification
{
    public class SVMClassifier : IClassifier
    {
        public void Classify(ref Person person, TrainingSet list)
        {
            var faceAttribute = new FaceAttribute();

            SVMT svm = new SVMT();
            var result = svm.SVMTT(person.FaceofP, list);
            if (faceAttribute.IsBinary)
            {
                faceAttribute.SortedClasses.Add(result == 1 ? 2 : 1);
            }
            person.FaceofP.FaceAttributes.Add(faceAttribute);
            //return probeImage;
        }
    }
}
