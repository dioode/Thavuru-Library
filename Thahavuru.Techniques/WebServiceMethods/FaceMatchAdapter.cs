using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.DataAccessLayer;
using Thahavuru.Techniques.Classification;


namespace Thahavuru.Techniques.WebServiceMethods
{
    public class FaceMatchAdapter : IFaceMatchAdapter
    {
        public List<Person> FaceMatch(Person inputPerson) 
        {

        }
        
        public Person FillAttributeValues(Person inputPerson, FaceAttributeHiearachy providedHiearachy) 
        {
            foreach (var faceAttribute in providedHiearachy.OrderedFaceAttributeSet)
            {
                var trainigSet = faceAttribute.GetTrainingSet();
                switch (faceAttribute.ClassificationTechnique)
	            {
                    case "PCA":
                        new PCAClassifier().Classify(ref inputPerson, trainigSet);
                        break;
                    case "LDA":
                        new LDAClassifier().Classify(ref inputPerson, trainigSet);
                        break;
                    case "SVM":
                        new SVMClassifier().Classify(ref inputPerson, trainigSet);
                        break;
	            }
                
            }
            return inputPerson;
        }
    }
}
