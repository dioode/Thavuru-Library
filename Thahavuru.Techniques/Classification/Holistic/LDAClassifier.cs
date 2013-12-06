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
            var result = lda.FLDT(person.FaceofP, list, currentAttrubute.Name.Trim());
            faceAttribute.SortedClasses.Add(result.Label);
            faceAttribute.ClassesInOrder.Add(currentAttrubute.ClassesInOrder.Where(x => x.ClassNumber == Convert.ToInt32( result.Label)).First());
            if (currentAttrubute.IsBinary)
            {
                int nextClassNumber = result.Label==1?2:1;
                faceAttribute.SortedClasses.Add(nextClassNumber);
                faceAttribute.ClassesInOrder.Add(currentAttrubute.ClassesInOrder.Where(x => x.ClassNumber == nextClassNumber).First());
            }
            faceAttribute.Name = currentAttrubute.Name;
            person.FaceofP.FaceAttributes.Add(faceAttribute);
        }
    }
}