using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.ClassificationT;
using Thahavuru.Techniques.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public class PCAClassifier : IClassifier
    {

        public Face Classify(Face probeImage, TrainingSet list, FaceAttribute faceAttribute)
        {
            PCA pca = new PCA();
            var result = pca.PCAT(probeImage, list);
            int i = 0;
            foreach (var item in result)
            {
                
            }
            while (i < faceAttribute.NumberOfClasses - 1)
            {
                  
            }
            
            faceAttribute.SortedClasses.Add(result);
            probeImage.FaceAttributes.Add(faceAttribute);
            return probeImage;
        }
    }
}
