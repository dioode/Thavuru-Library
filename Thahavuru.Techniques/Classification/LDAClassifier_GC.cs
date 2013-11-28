using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.ClassificationT;

namespace Thahavuru.Techniques.Classification
{
    public class LDAClassifier_GC
    {
        public void RecognizeGC_LDA(ref PersonVM person, TrainingSet list, int NumberOfResults, int PageNumber)
        {
            if (person.MatchedFaceIdSet[PageNumber] == null)
            {
                List<int> matchedFaces = new List<int>();

                LDA lda = new LDA();
                int[] condition = { NumberOfResults, list.trainingList.Count };

                for (int i = 0; i < condition.Min(); i++)
                {
                    var result = lda.FLDT(person.FaceofP, list);

                    if (result.Distance != 0.0)
                    {
                        matchedFaces.Add(result.Label);
                        list.labelList.RemoveAt(Convert.ToInt32(result.Label));
                        list.trainingList.RemoveAt(Convert.ToInt32(result.Label));
                    }
                }
                person.MatchedFaceIdSet.Add(PageNumber, matchedFaces);
            }
        }

        public void ClassifyGC_LDA(ref PersonVM person, TrainingSet list, FaceAttribute Attribute) 
        {
            if (Attribute.NumberOfClasses <= Attribute.SortedClasses.Count) return;
            LDA lda = new LDA();
            
            #region Remove Images which alrady added to Attribute.sortedList
            for (int j = 0; j < Attribute.SortedClasses.Count; j++)
            {
                for (int i = list.trainingList.Count - 1; i > -1; i--)
                {
                    if (list.labelList[i] == Attribute.SortedClasses[j])
                    {
                        list.labelList.RemoveAt(i);
                        list.trainingList.RemoveAt(i);
                    }
                }
            }
            #endregion

            // calculate next attribute
            try
            {
                FaceRecognizer.PredictionResult result = lda.FLDT(person.FaceofP, list);
                Attribute.SortedClasses.Add(result.Label);
            }
            catch { }

            person.FaceofP.FaceAttributes.Add(Attribute); ;
        }
    }
}
