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
        public void MatchFacesUsingPCA(ref Person person) 
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person.FaceofP.FaceAttributes);
            PCA pca = new PCA();
            var matchingOrderedSet = pca.PCAT(person.FaceofP, faceImageListafterPruning);

            //Somehow 
        }

        public void MatchFacesLDA(ref Person person)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person.FaceofP.FaceAttributes);
            LDA lda = new LDA();
            var matchingOrderedSet = lda.FLDT(person.FaceofP, faceImageListafterPruning);
        }

        public void MatchFacesSVM(ref Person person)
        {
            var faceImageListafterPruning = GetAllPeopleUnderNarrowdown(person.FaceofP.FaceAttributes);
            SVMT svm = new SVMT();
            var matchingOrderedSet = svm.SVMTT(person.FaceofP, faceImageListafterPruning);
        }

        private TrainingSet GetAllPeopleUnderNarrowdown(List<FaceAttribute> faceAttributeList) 
        {
            return new TrainingSet();
        }
    }
}
