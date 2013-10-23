using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.ClassificationT;
using Thahavuru.Techniques.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public class LDAClassifier : IClassifier
    {
        public Face Classify(Face probeImage, TrainingSet list, FaceAttribute faceAttribute)
        {
            LDA lda = new LDA();
            var result = lda.FLDT(probeImage, list);
            faceAttribute.SortedClasses.Add(result.Label);
            if (faceAttribute.IsBinary)
            {
                faceAttribute.SortedClasses.Add(result.Label==1?2:1);
            }

            probeImage.FaceAttributes.Add(faceAttribute);
            return probeImage;
        }
    }
}