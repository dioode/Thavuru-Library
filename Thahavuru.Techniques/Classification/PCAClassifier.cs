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

        public void Classify(ref PersonVM person, TrainingSet list)
        {
            var faceAttribute = new FaceAttribute();

            PCA pca = new PCA();
            var result = pca.PCAT(person.FaceofP, list);
            foreach (var item in result)
            {
                
                faceAttribute.SortedClasses.Add(item);
            }

            person.FaceofP.FaceAttributes.Add(faceAttribute);
            //return probeImage;
        }
    }
}
