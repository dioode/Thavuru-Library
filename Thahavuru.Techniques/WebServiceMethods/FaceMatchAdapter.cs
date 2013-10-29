using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.DataAccessLayer;
using Thahavuru.Techniques.Classification;
using Thahavuru.Techniques.FaceRec ;


namespace Thahavuru.Techniques.WebServiceMethods
{
    public class FaceMatchAdapter //: IFaceMatchAdapter
    {
        private FaceRecognition faceRecContext;
        public FaceMatchAdapter()
        {
            faceRecContext = new FaceRecognition();
            var attributeSet = GetCurrentConfigAttrubuteSet();
        }

        public void FaceMatch(ref UserInterfaceModel userInterfacemodel) 
        {
            var attributeSet = GetCurrentConfigAttrubuteSet();

            if (userInterfacemodel.SearchingPerson.FaceofP.FaceAttributes == null) 
            {
                FillAttributeValues(ref userInterfacemodel.SearchingPerson, attributeSet);
                faceRecContext.MatchFaces(ref userInterfacemodel.SearchingPerson, "LDA", userInterfacemodel.PageNumber); //This is hard-coded, have to change this

            }
            else
            {
                if (userInterfacemodel.Next == true)
                {
                    if (userInterfacemodel.SearchingPerson.MatchedFaceIdSet.Count < userInterfacemodel.PageNumber + 1)
                    faceRecContext.MatchFaces(ref userInterfacemodel.SearchingPerson, "LDA", userInterfacemodel.PageNumber + 1); //This is hard-coded, have to change this
                }
            }
        }

        private FaceAttributeHiearachy GetCurrentConfigAttrubuteSet() 
        {
            return new FaceAttributeHiearachy();
            //Get from database.
        }
        
        private void FillAttributeValues(ref PersonVM inputPerson, FaceAttributeHiearachy providedHiearachy) 
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
        }
    }
}
