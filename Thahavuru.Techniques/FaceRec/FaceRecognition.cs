using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.ClassificationT;


namespace Thahavuru.Techniques.FaceRec
{
    public class FaceRecognition
    {
        public void MatchFaces(ref Person person, string technique, int pageNumber) 
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
        private void MatchFacesUsingPCA(ref Person person, int pageNumber) 
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person.FaceofP.FaceAttributes, pageNumber);
            PCA pca = new PCA();
            var matchingOrderedSet = pca.PCAT(person.FaceofP, faceImageListafterPruning);

            //Somehow 
        }

        private void MatchFacesLDA(ref Person person, int pageNumber)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person.FaceofP.FaceAttributes, pageNumber);
            LDA lda = new LDA();
            var matchingOrderedSet = lda.FLDT(person.FaceofP, faceImageListafterPruning);
        }

        private void MatchFacesSVM(ref Person person, int pageNumber)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person.FaceofP.FaceAttributes, pageNumber);
            SVMT svm = new SVMT();
            var matchingOrderedSet = svm.SVMTT(person.FaceofP, faceImageListafterPruning);
        }

        private TrainingSet GetAllPeopleUnderNarrowdown(List<FaceAttribute> faceAttributeList, int pageNumber) 
        {
            //return training set according to attribute set and the page number
            //ToDo: 
            return new TrainingSet();
        }
    }
}
