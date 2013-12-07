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
        /// <summary>
        /// This is to get 'n' number of best matching faces from Fisher Linear Discriminent Analysis. 
        /// Then add that result to person object according to requested pagenumber.
        /// </summary>
        /// <param name="person">this object contains the prob image and matched faces list</param>
        /// <param name="list">faces image set in selected leaf of decision tree</param>
        /// <param name="NumberOfResults">number of matching images needed i.e. 10 results</param>
        /// <param name="PageNumber">requested page number</param>
        public void RecognizeGC_LDA(ref PersonVM person, TrainingSet list, int NumberOfResults, int PageNumber)
        {
            List<int> matchedFaces = new List<int>();
            
            LDA lda = new LDA();
            int[] condition = { NumberOfResults, list.trainingList.Count };//face images in selected leaf and requested matching images count

            
            for (int i = 0; i < condition.Min(); i++) 
            {
                if (list.labelList.Count ==1)
                {
                    matchedFaces.Add(list.labelList[0]);
                }
                else
                {
                    var result = lda.FLDT(person.FaceofP, list);
                    matchedFaces.Add(result.Label);
                        int index = list.labelList.IndexOf(result.Label);
                    list.labelList.RemoveAt(index);// remove current best matching image to get next best maching image
                    list.trainingList.RemoveAt(index);
                }
            }
            person.MatchedFaceIdSet.Add(PageNumber, matchedFaces);
        }

        /// <summary>
        /// This method for classify given probe image accordig to given attribute. 
        /// This method used in lazy loading.
        /// (i.e. if one attribute has 3 classes and we know the best matching class for given image, and 
        /// we want to get next best matching class from rest of 2 classes)
        /// </summary>
        /// <param name="person">this object contains the prob image and matched faces list</param>
        /// <param name="list">faces image set in selected leaf of decision tree</param>
        /// <param name="attribute">attribute</param>
        public void ClassifyGC_LDA(ref PersonVM person, TrainingSet list, FaceAttribute attribute) 
        {
            if (attribute.NumberOfClasses <= attribute.SortedClasses.Count) return;// if all classes are alrady found
            LDA lda = new LDA();
            
            #region Remove Images which alrady in sorted classes

            for (int j = 0; j < attribute.SortedClasses.Count; j++)
            {
                for (int i = list.trainingList.Count - 1; i > -1; i--)
                {
                    if (list.labelList[i] == attribute.SortedClasses[j])
                    {
                        list.labelList.RemoveAt(i);
                        list.trainingList.RemoveAt(i);
                    }
                }
            }

            #endregion

            try
            {
                FaceRecognizer.PredictionResult result = lda.FLDT(person.FaceofP, list, attribute.Name);
                attribute.SortedClasses.Add(result.Label);
            }
            catch { }
            person.FaceofP.FaceAttributes.Add(attribute); ;
        }
    }
}
