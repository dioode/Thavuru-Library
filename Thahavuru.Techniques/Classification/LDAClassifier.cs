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
        public void Classify(ref Person person, TrainingSet list)
        {
           
            var faceAttribute = new FaceAttribute();

            LDA lda = new LDA();
            var result = lda.FLDT(person.FaceofP, list);
            faceAttribute.SortedClasses.Add(result.Label);
            if (faceAttribute.IsBinary)
            {
                faceAttribute.SortedClasses.Add(result.Label==1?2:1);
            }

            person.FaceofP.FaceAttributes.Add(faceAttribute);
            //return probeImage;
        }
    }
}