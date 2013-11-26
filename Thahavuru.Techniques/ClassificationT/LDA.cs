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
                FisherFaceRecognizer faceRecognizer = new FisherFaceRecognizer(80, double.PositiveInfinity);
                
                faceRecognizer.Train(tSet.trainingList.ToArray(), tSet.labelList.ToArray());
                
                result = faceRecognizer.Predict(probeImage.FaceImage);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result.Label = tSet.labelList.First();
                return result;
            }
            finally 
            {
                
            }
        }
    }
}
