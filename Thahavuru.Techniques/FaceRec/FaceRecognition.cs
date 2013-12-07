using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.DataAccessLayer;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.Classification;
using Thahavuru.Techniques.ClassificationT;


namespace Thahavuru.Techniques.FaceRec
{
    public class FaceRecognition
    {
        private DataAccessSingleton dataAccessContext;
        public FaceRecognition()
        {
            dataAccessContext = DataAccessSingleton.Instance;
        }

        /// <summary>
        /// Final Face matching for images in the leave
        /// </summary>
        /// <param name="person"></param>
        /// <param name="technique"></param>
        /// <param name="pageNumber"></param>
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

        #region Facematching techniques implimentations (PCA, LDA)

        private void MatchFacesUsingPCA(ref PersonVM person, int pageNumber)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person, pageNumber);
            PCA pca = new PCA();
            var matchingOrderedSet = pca.PCAT(person.FaceofP, faceImageListafterPruning);

        }

        private void MatchFacesLDA(ref PersonVM person, int pageNumber)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person, pageNumber);
            LDAClassifier_GC lda_gc = new LDAClassifier_GC();
            lda_gc.RecognizeGC_LDA(ref person, faceImageListafterPruning, 10, pageNumber);
        }

        private void MatchFacesSVM(ref PersonVM person, int pageNumber)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person, pageNumber);
            SVMT svm = new SVMT();
            var matchingOrderedSet = svm.SVMTT(person.FaceofP, faceImageListafterPruning);
        }

        #endregion

        /// <summary>
        /// Data access caller for GetAllNarrowdownFaceImageSet
        /// </summary>
        /// <param name="person"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        private TrainingSet GetAllPeopleUnderNarrowdown(PersonVM person, int pageNumber)
        {
            return dataAccessContext.GetAllNarrowdownFaceImageSet(person, pageNumber);
        }
    }
}
