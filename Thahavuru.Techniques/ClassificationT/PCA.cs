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
    public class PCA
    {
        public List<int> PCAT(IFace probeImage, TrainingSet tSet)
        {
            List<int> idx = null;
            float[] f = null;
            string[] a = null;
            List<KeyValuePair<float, int>> resultsList = new List<KeyValuePair<float, int>>();
            try
            {
                MCvTermCriteria termCrit = new MCvTermCriteria(16, 0.001);
                EigenObjectRecognizer recognizer = new EigenObjectRecognizer(tSet.trainingList.ToArray(), tSet.labelListS.ToArray(), 5000, ref termCrit);
                if (recognizer.Recognize(probeImage.FaceImage) != null)
                {
                    f = recognizer.GetEigenDistances(probeImage.FaceImage);
                    a = recognizer.Labels;
                    for (int i = 0; i < f.Count(); i++)
                    {
                        resultsList.Add(new KeyValuePair<float, int>(f[i], Convert.ToInt32(a[i])));
                    }
                    var sorted = resultsList.OrderBy(x => x.Key).ToList();
                    idx = sorted.Select(x => x.Value).ToList();
                }
                else
                {
                    idx = tSet.labelList;
                }

                return idx;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return idx;
            }
        }
    }
}
