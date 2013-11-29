using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.ClassificationT;
using Thahavuru.Resources.ViewModels;


namespace Thahavuru.Techniques.Classification
{
    public class LDAClassifier : IClassifier
    {
        public void Classify(ref PersonVM person, TrainingSet list, FaceAttribute currentAttrubute)
        {
           
            var faceAttribute = new FaceAttribute();
            faceAttribute.AttributeId = currentAttrubute.AttributeId;
            faceAttribute.NumberOfClasses = currentAttrubute.NumberOfClasses;
            faceAttribute.IsBiometric = currentAttrubute.IsBiometric;
            faceAttribute.Name = currentAttrubute.Name;
            faceAttribute.ClassificationTechnique = currentAttrubute.ClassificationTechnique;

            LDA lda = new LDA();
            var result = lda.FLDT(person.FaceofP, list);
            faceAttribute.SortedClasses.Add(result.Label);
            if (currentAttrubute.IsBinary)
            {
                faceAttribute.SortedClasses.Add(result.Label==1?2:1);
            }

            person.FaceofP.FaceAttributes.Add(faceAttribute);
            //return probeImage;
        }
    }
}