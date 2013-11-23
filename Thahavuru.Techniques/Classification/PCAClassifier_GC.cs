using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.ClassificationT;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public class PCAClassifier_GC
    {
        public void RecognizeGC_PCA(ref PersonVM person, TrainingSet list, int NumberOfResults, int PageNumber)
        {
            List<int> matchedFaces = new List<int>();
            PCA pca = new PCA();
            int[] condition = { NumberOfResults, list.trainingList.Count };
            var result = pca.PCAT(person.FaceofP, list);

            for (int i = 0; i < condition.Min(); i++)
            {
                matchedFaces.Add(result.ElementAt(i));
            }

            person.MatchedFaceIdSet.Add(PageNumber, matchedFaces);
        }

        public void ClassifyGC_PCA(ref PersonVM person, TrainingSet list, FaceAttribute Attribute)
        {
            if (Attribute.NumberOfClasses <= Attribute.SortedClasses.Count) return;
            PCA pca = new PCA();

            //#region Remove Images which alrady added to Attribute.sortedList
            //for (int j = 0; j < Attribute.SortedClasses.Count; j++)
            //{
            //    for (int i = list.trainingList.Count - 1; i > -1; i--)
            //    {
            //        if (list.labelList[i] == Attribute.SortedClasses[j])
            //        {
            //            list.labelList.RemoveAt(i);
            //            list.trainingList.RemoveAt(i);
            //        }
            //    }
            //}
            //#endregion

            // calculate next attribute
            try
            {
                var result = pca.PCAT(person.FaceofP, list);
                var classes = distinctClasses(result);
                Attribute.SortedClasses.AddRange(classes);
            }
            catch { }

            person.FaceofP.FaceAttributes.Add(Attribute);
        }

        private List<int> distinctClasses(List<int> allClasses) 
        {
            List<int> distinct = new List<int>();
            foreach (int value in allClasses) 
            {
                if (!distinct.Contains(value)) 
                {
                    distinct.Add(value);
                }
            }
            return distinct;
        }

    }
}
