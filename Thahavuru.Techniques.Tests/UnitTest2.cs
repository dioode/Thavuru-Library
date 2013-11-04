using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Thahavuru.Techniques.FaceRecT;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class BiometricMethods
    {
        [TestMethod]
        public void FindRatios()
        {
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"biometric/eyenoseratio.txt");
            System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"biometric/eyemouthratio.txt");
            System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"biometric/nosemouthratio.txt");

            
            for (int i = 0; i < 412; i++)
            {
                DecoratedImageWithFeatures set =null;
                
                string imageName = "user(" + i.ToString() +")" + ".jpg";
                string Path = "biometric/" + imageName;
                using (Image img = System.Drawing.Image.FromFile(Path))
                {
                    FeatureTracker ft = new FeatureTracker(img);
                    set = ft.GetFeaturePoints();
              
                }

                double noseeyesratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[0].X - set.facialFeatureSet[1].X, 2) + Math.Pow(set.facialFeatureSet[0].Y - set.facialFeatureSet[1].Y, 2)) / Math.Sqrt(Math.Pow(set.facialFeatureSet[22].X - set.facialFeatureSet[22].X, 2) + Math.Pow(set.facialFeatureSet[49].Y - set.facialFeatureSet[49].Y, 2)) ;
                file1.WriteLine(noseeyesratio);
                double eyemouthratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[0].X - set.facialFeatureSet[1].X, 2) + Math.Pow(set.facialFeatureSet[0].Y - set.facialFeatureSet[1].Y, 2)) / Math.Sqrt(Math.Pow(set.facialFeatureSet[3].X - set.facialFeatureSet[4].X, 2) + Math.Pow(set.facialFeatureSet[3].Y - set.facialFeatureSet[4].Y, 2));
                file1.WriteLine(noseeyesratio);
                double nosemouthratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[22].X - set.facialFeatureSet[49].X, 2) + Math.Pow(set.facialFeatureSet[22].Y - set.facialFeatureSet[49].Y, 2)) / Math.Sqrt(Math.Pow(set.facialFeatureSet[3].X - set.facialFeatureSet[4].X, 2) + Math.Pow(set.facialFeatureSet[3].Y - set.facialFeatureSet[4].Y, 2));
                file1.WriteLine(noseeyesratio);

                
                
            }
            
        }
    }
}
