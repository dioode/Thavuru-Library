using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.DataAccessLayer;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.ClassificationT;


namespace Thahavuru.Techniques.FaceRec
{
    public class FaceRecognition
    {
        private DataAccessSingleton dataAccessContext;
        public FaceRecognition()
        {
            dataAccessContext = new DataAccessSingleton();
        }

        public void MatchFaces(ref PersonVM person, string technique, int pageNumber) 
        {
            switch (technique)
            {
                case "PCA":
                    MatchFacesUsingPCA(ref person, pageNumber);
                    break;
                case "LDA":
                    MatchFacesLDA(ref person, pageNumber);
                    break;
                case "SVM":
                    MatchFacesSVM(ref person, pageNumber);
                    break;
                default:
                    break;
            }
        }
        private void MatchFacesUsingPCA(ref PersonVM person, int pageNumber) 
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person, pageNumber);
            PCA pca = new PCA();
            var matchingOrderedSet = pca.PCAT(person.FaceofP, faceImageListafterPruning);

            //Somehow 
        }

        private void MatchFacesLDA(ref PersonVM person, int pageNumber)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person, pageNumber);
            LDA lda = new LDA();
            var matchingOrderedSet = lda.FLDT(person.FaceofP, faceImageListafterPruning);
        }

        private void MatchFacesSVM(ref PersonVM person, int pageNumber)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person, pageNumber);
            SVMT svm = new SVMT();
            var matchingOrderedSet = svm.SVMTT(person.FaceofP, faceImageListafterPruning);
        }

        private TrainingSet GetAllPeopleUnderNarrowdown(PersonVM person, int pageNumber) 
        {
            return dataAccessContext.GetAllNarrowdownFaceImageSet(person, pageNumber);
        }
    }
}
