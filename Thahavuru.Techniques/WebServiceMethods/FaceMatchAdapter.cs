﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.DataAccessLayer;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.Classification;
using Thahavuru.Techniques.FaceRec;


namespace Thahavuru.Techniques.WebServiceMethods
{
    public class FaceMatchAdapter //: IFaceMatchAdapter
    {
        private FaceRecognition faceRecContext;
        private DataAccessSingleton dataAccessSingleton;
        public FaceMatchAdapter()
        {
            faceRecContext = new FaceRecognition();
            dataAccessSingleton = DataAccessSingleton.Instance;

        }

        public void FaceMatch(ref UserInterfaceModel userInterfacemodel)
        {
            if (userInterfacemodel != null)
            {
                if (userInterfacemodel.SearchingPerson.MatchedFaceIdSet.ContainsKey(userInterfacemodel.PageNumber))
                {
                    return;
                }
                var attributeSet = LoadHieararchy();
                if (userInterfacemodel.MaxLeaves == 0)
                {
                    int x = 1;
                    foreach (var item in attributeSet.OrderedFaceAttributeSet)
                    {
                        x *= item.NumberOfClasses;
                    }

                    userInterfacemodel.MaxLeaves = x;
                }


                if (userInterfacemodel.MaxLeaves >= userInterfacemodel.PageNumber)
                {
                    if (userInterfacemodel.SearchingPerson.FaceofP.FaceAttributes.Count == 0)
                    {
                        FillAttributeValues(ref userInterfacemodel.SearchingPerson, attributeSet);
                    }

                    FillSearchTrackForNumber(ref userInterfacemodel.SearchingPerson, userInterfacemodel.PageNumber, userInterfacemodel.MaxLeaves);

                    faceRecContext.MatchFaces(ref userInterfacemodel.SearchingPerson, attributeSet.FaceMatchingTechnique, userInterfacemodel.PageNumber); //This is hard-coded, have to change this
                }
            }
        }

        private FaceAttributeHiearachy LoadHieararchy()
        {
            return dataAccessSingleton.GetFaceAttributeHierarchy();
        }

        private void FillAttributeValues(ref PersonVM inputPerson, FaceAttributeHiearachy providedHiearachy)
        {
            foreach (var faceAttribute in providedHiearachy.OrderedFaceAttributeSet)
            {
                if (!faceAttribute.IsBiometric)
                {
                    var trainigSet = dataAccessSingleton.GetTraingSet(faceAttribute.AttributeId);
                    FillHolisticAttributes(ref inputPerson, trainigSet, faceAttribute);
                }
                else
                {
                    FillBiometricAttributes(ref inputPerson, faceAttribute);
                }
            }
        }

        private void FillHolisticAttributes(ref PersonVM inputPerson, TrainingSet trainigSet, FaceAttribute faceAttribute)
        {
            new HolisticAttributeFiller().Classify(ref inputPerson, trainigSet, faceAttribute);

        }

        private void FillBiometricAttributes(ref PersonVM inputPerson, FaceAttribute faceAttribute)
        {
            new BiometricAttributeFiller().FillBiometricAttributes(inputPerson, faceAttribute);

        }

        /// <summary>
        /// Loads SearchTrackKeeper which contains the paths to the leaves in decision tree
        /// </summary>
        /// <param name="inputPerson"></param>
        /// <param name="pageNumber"></param>
        /// <param name="maxLeaves"></param>
        private void FillSearchTrackForNumber(ref PersonVM inputPerson, int pageNumber, int maxLeaves)
        {
            if (inputPerson.SearchTrakKeeper.Count == 0)
            {
                int i = 0;
                List<List<int>> listNumbers = new List<List<int>>();
                foreach (var item in inputPerson.FaceofP.FaceAttributes)
                {
                    var kk = new List<int>() { ++i, item.SortedClasses[0], 1 };
                    listNumbers.Add(kk);
                }

                inputPerson.SearchTrakKeeper.Add(listNumbers);
            }

            // If given number is larger than the total paths it can take then there is a issue
            if (pageNumber <= maxLeaves && pageNumber > 0)
            {

                //If the attribute list is less than y that menas you have to calculate rest of the paths before giving the y th search path attrubutes.
                if (inputPerson.SearchTrakKeeper.Count < pageNumber)
                {
                    //If the number of classes for attribute is less than existing class attribute number that means
                    //you have to find it out first

                    for (int p = inputPerson.SearchTrakKeeper.Count; p < pageNumber; p++)
                    {
                        int h = p - 1; // Previous SearchPath List Index

                        int d = inputPerson.SearchTrakKeeper[h].Count - 1; //This is the index for last added set of classes for a particular attribute.

                        bool bol = true;
                        while (bol)
                        {
                            int currentLevel = inputPerson.SearchTrakKeeper[h][d][0];
                            int currentClassLable = inputPerson.SearchTrakKeeper[h][d][1];

                            if (inputPerson.SearchTrakKeeper[h][d][2] < inputPerson.FaceofP.FaceAttributes[currentLevel - 1].NumberOfClasses)
                            {
                                int indexOfCurrentClassLable = inputPerson.FaceofP.FaceAttributes[currentLevel - 1].SortedClasses.IndexOf(currentClassLable);
                                List<List<int>> temp = new List<List<int>>();

                                foreach (var item in inputPerson.SearchTrakKeeper[h].GetRange(0, d + 1).ToList())
                                {
                                    temp.Add(new List<int>(item));
                                }

                                if (indexOfCurrentClassLable + 1 < inputPerson.FaceofP.FaceAttributes[currentLevel - 1].SortedClasses.Count)
                                {
                                    temp[d][1] = inputPerson.FaceofP.FaceAttributes[currentLevel - 1].SortedClasses[indexOfCurrentClassLable + 1];
                                    temp[d][2] += 1;
                                }

                                else if (inputPerson.FaceofP.FaceAttributes[currentLevel - 1].SortedClasses.Count < inputPerson.FaceofP.FaceAttributes[currentLevel - 1].NumberOfClasses)
                                {
                                    //Find the missing attribute classes in the attrbuteList and then assing the

                                    var currentAttrubute = inputPerson.FaceofP.FaceAttributes[currentLevel - 1];
                                    var CurrentTrainingSet = dataAccessSingleton.GetTraingSet(currentAttrubute.AttributeId);

                                    switch (currentAttrubute.ClassificationTechnique.Trim())
                                    {
                                        case "LDA":
                                            new LDAClassifier_GC().ClassifyGC_LDA(ref inputPerson, CurrentTrainingSet, currentAttrubute);
                                            break;
                                        case "PCA":
                                            new PCAClassifier_GC().ClassifyGC_PCA(ref inputPerson, CurrentTrainingSet, currentAttrubute);
                                            break;
                                        default:
                                            break;
                                    }

                                    temp[d][1] = inputPerson.FaceofP.FaceAttributes[currentLevel - 1].SortedClasses[indexOfCurrentClassLable + 1];
                                    temp[d][2] += 1;
                                }
                                inputPerson.SearchTrakKeeper.Add(temp);

                                for (int l = temp.Count; l < inputPerson.FaceofP.FaceAttributes.Count; l++)
                                {
                                    inputPerson.SearchTrakKeeper[h + 1].Add(new List<int>() { l+1, inputPerson.FaceofP.FaceAttributes[l].SortedClasses[0], 1 });
                                }

                                bol = false;
                            }
                            d -= 1;
                            if (d == -1)
                            {
                                bol = false;
                            }
                        }

                    }

                }
                // Else You can send the existing attribute path.
                //else
                //{
                //    //Already contains the list in the model up to the page number
                //}
            }
            //else
            //{
            //    //This has exceeded the limits
            //}
        }
    }
}
