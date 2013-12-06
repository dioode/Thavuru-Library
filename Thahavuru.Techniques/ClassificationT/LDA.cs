using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.Techniques.ClassificationT
{
    public class LDA
    {
        /// <summary>
        /// This is core algorithm of fisher face recognizer.
        /// in implimentation we have used the EmguCV libraries.
        /// we use this method for both face classification and recognition purposes.
        /// </summary>
        /// <param name="probeImage"> This contains the prob image used for classification or recogniton. </param>
        /// <param name="tSet"> Training set for classification or train Images. </param>
        /// <returns>
        /// if no duplicate classes return the predicted result from fisher face recognizer, 
        /// other wise return default value.
        /// </returns>
        public FaceRecognizer.PredictionResult FLDT(IFace probeImage, TrainingSet tSet)
        {
            FaceRecognizer.PredictionResult result = default(FaceRecognizer.PredictionResult);
            try
            {
                var duplicates = tSet.labelList.GroupBy(a => a).SelectMany(ab => ab.Skip(1).Take(1)).ToList();
                if (duplicates.Count != 1)
                {
                    //First parameter of Fisher face recognizer is number of components kept Linear Discriminant Analysis with the Fisherfaces criterion.
                    //we put default value 0 to keep all components, this means the number of your training inputs.
                    //Second parameter is threshold value. 
                    FisherFaceRecognizer faceRecognizer = new FisherFaceRecognizer(0, double.PositiveInfinity);
                    faceRecognizer.Train(tSet.trainingList.ToArray(), tSet.labelList.ToArray());
                    result = faceRecognizer.Predict(probeImage.FaceImage);
                    return result;
                }
                else 
                {
                    result.Label = tSet.labelList.First();
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        /// <summary>
        /// This is overloaded metod for read training data from Yml file 
        /// </summary>
        /// <param name="probeImage">probe image</param>
        /// <param name="tSet">training set</param>
        /// <param name="trainedFileName">yml file name fro each attribute</param>
        /// <returns>prediction result for face recognizer</returns>
        public FaceRecognizer.PredictionResult FLDT(IFace probeImage, TrainingSet tSet, string trainedFileName)
        {
            FaceRecognizer.PredictionResult result = default(FaceRecognizer.PredictionResult);
            try
            {
                var duplicates = tSet.labelList.GroupBy(a => a).SelectMany(ab => ab.Skip(1).Take(1)).ToList();
                if (duplicates.Count != 1)
                {
                    FisherFaceRecognizer faceRecognizer = new FisherFaceRecognizer(0, double.PositiveInfinity);
                    string fileName = trainedFileName + ".yml";

                    if (File.Exists(fileName))
                    {
                        faceRecognizer.Load(fileName);
                    }
                    else
                    {
                        faceRecognizer.Train(tSet.trainingList.ToArray(), tSet.labelList.ToArray());
                        faceRecognizer.Save(fileName);
                    }
                    result = faceRecognizer.Predict(probeImage.FaceImage);
                    return result;
                }
                else
                {
                    result.Label = tSet.labelList.First();
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    
    }
}
