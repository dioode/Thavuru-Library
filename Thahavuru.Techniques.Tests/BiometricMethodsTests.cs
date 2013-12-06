using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Thahavuru.Techniques.FaceRecT;
using Thahavuru.Resources.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class BiometricMethods
    {
        [TestMethod]
        public void BiometricMethods_FindRatios()//C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow
        {

            try
            {
                //List<double> noseeyesratioList = new List<double>();
                //List<double> eyemouthratioList = new List<double>();
                //List<double> nosemouthratioList = new List<double>();
                List<double> eyesEyeBrowsRatioList = new List<double>();


                for (int i = 400; i < 419; i++)
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
                        //noseeyesratioList.Add(-1);
                        //eyemouthratioList.Add(-1);
                        //nosemouthratioList.Add(-1);
                        eyesEyeBrowsRatioList.Add(-1);
                    }

                    if (set != null)
                    {
                        //double innerEyesNoseratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[24].X - set.facialFeatureSet[25].X, 2) + Math.Pow(set.facialFeatureSet[24].Y - set.facialFeatureSet[25].Y, 2)) / (Math.Sqrt(Math.Pow(set.facialFeatureSet[22].X - set.facialFeatureSet[49].X, 2) + Math.Pow(set.facialFeatureSet[22].Y - set.facialFeatureSet[49].Y, 2)));

                        //double eyeMouthratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[0].X - set.facialFeatureSet[1].X, 2) + Math.Pow(set.facialFeatureSet[0].Y - set.facialFeatureSet[1].Y, 2)) / (Math.Sqrt(Math.Pow(set.facialFeatureSet[3].X - set.facialFeatureSet[4].X, 2) + Math.Pow(set.facialFeatureSet[3].Y - set.facialFeatureSet[4].Y, 2)));

                        //double noseMouthratio = Math.Sqrt(Math.Pow(set.facialFeatureSet[22].X - set.facialFeatureSet[49].X, 2) + Math.Pow(set.facialFeatureSet[22].Y - set.facialFeatureSet[49].Y, 2)) / (Math.Sqrt(Math.Pow(set.facialFeatureSet[3].X - set.facialFeatureSet[4].X, 2) + Math.Pow(set.facialFeatureSet[3].Y - set.facialFeatureSet[4].Y, 2)));

                        double eyesEyeBrowsRatio = Math.Sqrt(Math.Pow(set.facialFeatureSet[23].X - set.facialFeatureSet[26].X, 2) + Math.Pow(set.facialFeatureSet[23].Y - set.facialFeatureSet[26].Y, 2)) / (Math.Sqrt(Math.Pow(set.facialFeatureSet[12].X - set.facialFeatureSet[15].X, 2) + Math.Pow(set.facialFeatureSet[12].Y - set.facialFeatureSet[15].Y, 2)));


                        //noseeyesratioList.Add(innerEyesNoseratio);
                        //eyemouthratioList.Add(eyeMouthratio);
                        //nosemouthratioList.Add(noseMouthratio);
                        eyesEyeBrowsRatioList.Add(eyesEyeBrowsRatio);

                        Debug.WriteLine(i);

                    }

                }

                Debug.WriteLine("-----------");

                //using (System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"biometric/eyenoseratio.txt", true))
                //{
                //    foreach (var item in noseeyesratioList)
                //    {
                //        file1.WriteLine(item);
                //    }
                //}

                //using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"biometric/eyemouthratio.txt", true))
                //{
                //    foreach (var item in eyemouthratioList)
                //    {
                //        file2.WriteLine(item);
                //    }
                //}

                //using (System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"biometric/nosemouthratio.txt", true))
                //{
                //    foreach (var item in nosemouthratioList)
                //    {
                //        file3.WriteLine(item);
                //    }
                //}

                using (System.IO.StreamWriter file4 = new System.IO.StreamWriter(@"biometric/eyeseyebrowsratio.txt", true))
                {
                    foreach (var item in eyesEyeBrowsRatioList)
                    {
                        file4.WriteLine(item);
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
