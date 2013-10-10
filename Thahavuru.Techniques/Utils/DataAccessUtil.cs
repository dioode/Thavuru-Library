using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Thahavuru.Techniques.Utils
{
    public class DataAccessUtil
    {
        public static void GetImageData(List<string> trainName, List<Image<Gray, byte>> imageList, List<int> labelList)
        {
            int j = 0;
            string[] files = null, files2 = null;
            try
            {
                files = System.IO.Directory.GetFiles(@"D:\My Work\Testing Projects\Thahavuru\LDA\images\Male", "*.jpg");
            }
            catch (DirectoryNotFoundException ex) {
                Console.Write(ex.ToString());
            }
            

            while (j < 80)
            {
                labelList.Add(j);
                trainName.Add("face_" + j.ToString());
                imageList.Add(new Image<Gray, byte>(@files[j]));//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                j++;
            }

            try
            {
                files2 = System.IO.Directory.GetFiles(@"D:\My Work\Testing Projects\Thahavuru\LDA\images\Female", "*.jpg");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.Write(ex.ToString());
            }

            while (j < 160)
            {
                labelList.Add(j);
                trainName.Add("face2_" + j.ToString());
                imageList.Add(new Image<Gray, byte>(@files2[j - 80]));//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                j++;
            }
        }
    }
}
