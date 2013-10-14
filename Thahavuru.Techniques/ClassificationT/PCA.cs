using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.Utils;

namespace Thahavuru.Techniques.ClassificationT
{
    public class PCA
    {
        public void PCAT()
        {
            //int imageSize = 64;
            List<string> trainName = new List<string>();
            List<Image<Gray, byte>> imageList = new List<Image<Gray, byte>>();
            List<int> labelList = new List<int>();

            DataAccessUtil.GetImageData(trainName, imageList, labelList);

            Image<Gray, byte> testImage = new Image<Gray, byte>(@"D:\My Work\Testing Projects\Thahavuru\LDA\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //int n = -1;
            try
            {
                MCvTermCriteria termCrit = new MCvTermCriteria(16, 0.001);
                EigenObjectRecognizer recognizer = new EigenObjectRecognizer(imageList.ToArray(), trainName.ToArray(), 5000, ref termCrit);
                if (recognizer.Recognize(testImage) != null)
                {
                    float[] f = recognizer.GetEigenDistances(testImage);
                    Console.WriteLine(f.Min());
                    Console.WriteLine(f[0]);
                }
                
                //if (File.Exists("train_image_pca.yml"))
                //{
                //    faceRecognizer.Load("train_image_pca.yml");
                //}
                //else
                //{
                //    faceRecognizer.Train(imageList.ToArray(), labelList.ToArray());
                //    faceRecognizer.Save("train_image_pca.yml");
                //}
                //FaceRecognizer.PredictionResult result = faceRecognizer.Predict(testImage);


                //Console.WriteLine(result.Label.ToString());
                //Console.ReadLine();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
