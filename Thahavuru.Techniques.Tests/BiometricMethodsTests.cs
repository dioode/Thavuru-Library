using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Thahavuru.Techniques.FaceRecT;
using Thahavuru.Resources.ViewModels;
using System.Collections.Generic;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class BiometricMethods
    {
        [TestMethod]
        public void FindRatios()//C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow
        {

            try
            {
                List<double> noseeyesratioList = new List<double>();
                List<double> eyemouthratioList = new List<double>();
                List<double> nosemouthratioList = new List<double>();


                for (int i = 401; i < 414; i++)
                {
                    DecoratedImageWithFeatures set = null;

                    string imageName = "user (" + i.ToString() + ")" + ".jpg";
                    string path = @"biometric/" + imageName;
                    using (Image img = System.Drawing.Image.FromFile(path))
                    {
                        FeatureTracker ft = new FeatureTracker();
                        set = ft.GetFeaturePoints(img);


                    }
                    if (set == null)
                    {
                        noseeyesratioList.Add(-1);
                        eyemouthratioList.Add(-1);
                        nosemouthratioList.Add(-1);
                    }

                    if (set != null)
                    {
                        double noseeyesratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[0].X - set.facialFeatureSet[1].X, 2) + Math.Pow(set.facialFeatureSet[0].Y - set.facialFeatureSet[1].Y, 2)) / (Math.Sqrt(Math.Pow(set.facialFeatureSet[22].X - set.facialFeatureSet[49].X, 2) + Math.Pow(set.facialFeatureSet[22].Y - set.facialFeatureSet[49].Y, 2)));

                        double eyemouthratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[0].X - set.facialFeatureSet[1].X, 2) + Math.Pow(set.facialFeatureSet[0].Y - set.facialFeatureSet[1].Y, 2)) / (Math.Sqrt(Math.Pow(set.facialFeatureSet[3].X - set.facialFeatureSet[4].X, 2) + Math.Pow(set.facialFeatureSet[3].Y - set.facialFeatureSet[4].Y, 2)));

                        double nosemouthratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[22].X - set.facialFeatureSet[49].X, 2) + Math.Pow(set.facialFeatureSet[22].Y - set.facialFeatureSet[49].Y, 2)) / (Math.Sqrt(Math.Pow(set.facialFeatureSet[3].X - set.facialFeatureSet[4].X, 2) + Math.Pow(set.facialFeatureSet[3].Y - set.facialFeatureSet[4].Y, 2)));


                        noseeyesratioList.Add(noseeyesratio);
                        eyemouthratioList.Add(eyemouthratio);
                        nosemouthratioList.Add(nosemouthratio);

                    }

                }

                Console.WriteLine();

                using (System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"biometric/eyenoseratio.txt", true))
                {
                    foreach (var item in noseeyesratioList)
                    {
                        file1.WriteLine(item);
                    }
                }

                using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"biometric/eyemouthratio.txt", true))
                {
                    foreach (var item in eyemouthratioList)
                    {
                        file2.WriteLine(item);
                    }
                }

                using (System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"biometric/nosemouthratio.txt", true))
                {
                    foreach (var item in nosemouthratioList)
                    {
                        file3.WriteLine(item);
                    }
                }         

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
            
        }
    }
}
