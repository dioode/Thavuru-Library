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
        public FaceRecognizer.PredictionResult FLDT(IFace probeImage, TrainingSet tSet)
        {
            FaceRecognizer.PredictionResult result = default(FaceRecognizer.PredictionResult);
            try
            {
                var duplicates = tSet.labelList.GroupBy(a => a).SelectMany(ab => ab.Skip(1).Take(1)).ToList();
                if (duplicates.Count != 1)
                {
                    FisherFaceRecognizer faceRecognizer = new FisherFaceRecognizer(80, double.PositiveInfinity);
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
                
                return result;
            }
            finally 
            {
                
            }
        }


        public FaceRecognizer.PredictionResult FLDT(IFace probeImage, TrainingSet tSet, string trainedFileName)
        {
            FaceRecognizer.PredictionResult result = default(FaceRecognizer.PredictionResult);
            try
            {
                var duplicates = tSet.labelList.GroupBy(a => a).SelectMany(ab => ab.Skip(1).Take(1)).ToList();
                if (duplicates.Count != 1)
                {
                    FisherFaceRecognizer faceRecognizer = new FisherFaceRecognizer(80, double.PositiveInfinity);
                    string fileName = @"C:\" +trainedFileName + ".yml";

                    if (File.Exists(fileName))
                    {
                        faceRecognizer.Load(fileName);
                    }
                    else
                    {
                        faceRecognizer.Train(tSet.trainingList.ToArray(), tSet.labelList.ToArray());
                        faceRecognizer.Save(fileName);
                    }
                    //faceRecognizer.Train(tSet.trainingList.ToArray(), tSet.labelList.ToArray());
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

                return result;
            }
            finally
            {

            }
        }
    }
}
