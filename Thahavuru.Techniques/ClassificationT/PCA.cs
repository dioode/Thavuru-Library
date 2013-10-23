using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.Utils;
using Thahavuru.Techniques.ViewModels;

namespace Thahavuru.Techniques.ClassificationT
{
    public class PCA
    {
        public List<int> PCAT(Face probeImage, TrainingSet tSet)
        {
            List<int> idx = null;
            float[] f = null;
            try
            {
                MCvTermCriteria termCrit = new MCvTermCriteria(16, 0.001);
                EigenObjectRecognizer recognizer = new EigenObjectRecognizer(tSet.trainingList.ToArray(), tSet.labelListS.ToArray(), 5000, ref termCrit);
                if (recognizer.Recognize(probeImage.FaceImage) != null)
                {
                    f = recognizer.GetEigenDistances(probeImage.FaceImage);
                }

                var sorted = f.Select((x, i) => new KeyValuePair<float, int>(x, i)).OrderBy(x => x.Key).ToList();
                idx = sorted.Select(x => x.Value).ToList();
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
