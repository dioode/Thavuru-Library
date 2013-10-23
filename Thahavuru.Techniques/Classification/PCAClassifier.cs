using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.ClassificationT;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public class PCAClassifier : IClassifier
    {

        public IFace Classify(IFace probeImage, TrainingSet list, FaceAttribute faceAttribute)
        {
            PCA pca = new PCA();
            var result = pca.PCAT(probeImage, list);
            foreach (var item in result)
            {
                faceAttribute.SortedClasses.Add(item);
            }
            
            probeImage.FaceAttributes.Add(faceAttribute);
            return probeImage;
        }
    }
}
