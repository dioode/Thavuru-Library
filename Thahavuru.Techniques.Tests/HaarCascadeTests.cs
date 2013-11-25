using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thahavuru.Techniques.FaceRecT;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.Util;
using System.Diagnostics;
using Thahavuru.Techniques.FaceRec;
using System.Collections.Generic;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class HaarCascadeTests{
        [TestMethod]
        public void TestMethod1()
        {
            
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                CascadeConfig config = new CascadeConfig(img.Width, img.Width/2, 1.5, 4, @"haarcascade_frontalface_default.xml");

                HaarCascade_ context = new HaarCascade_();

                Rectangle[] imageSet = context.ObjectDetection(new Bitmap(img), config);

                Debug.WriteLine("Number if Faces: " + imageSet.Length);
                

                //Select the active page
                //img.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, 0);


                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }

                       

                    }

                    bmp.Save("c:\\bmp.bmp");
                }
            }

            //using (var gr = Graphics.FromImage(InputImg))
            //{
            //    foreach (var item in imageSet)
            //    {
            //        gr.DrawRectangle(Pens.Black, item);
            //    }
                
            //    //gr.FillRectangle(Brushes.Orange, new Rectangle(0, 0, InputImg.Width, InputImg.Height));
            //    var path = System.IO.Path.Combine(
            //        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            //        "Example.png");
            //    InputImg.Save(path);
            //}
        


        }

        [TestMethod]
        public void TestMethod2()
        {
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                FaceFeatureIdentification x = new FaceFeatureIdentification(img);

                List<Rectangle> imageSet = x.IndentifyRightEye();

                Debug.WriteLine("Number if Left Eyes: " + imageSet.Count);

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }



                    }

                    bmp.Save("c:\\bmp1.bmp");
                }
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                FaceFeatureIdentification x = new FaceFeatureIdentification(img);

                List<Rectangle> imageSet = x.IndentifyLeftEye();

                Debug.WriteLine("Number if Left Eyes: " + imageSet.Count);

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }



                    }

                    bmp.Save("c:\\bmp3.bmp");
                }
            }
        }


        [TestMethod]
        public void TestMethod4()
        {
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                FaceFeatureIdentification x = new FaceFeatureIdentification(img);

                List<Rectangle> imageSet = x.IdentifyNose();

                Debug.WriteLine("Number if Left Eyes: " + imageSet.Count);

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }



                    }

                    bmp.Save("c:\\bmp4.bmp");
                }
            }
        }


        [TestMethod]
        public void TestMethod5()
        {
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                FaceFeatureIdentification x = new FaceFeatureIdentification(img);

                List<Rectangle> imageSet = x.IndetifyMouth();

                Debug.WriteLine("Number if Left Eyes: " + imageSet.Count);

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }
                    }

                    bmp.Save("c:\\bmp5.bmp");
                }
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                FaceFeatureIdentification x = new FaceFeatureIdentification(img);

                List<Rectangle> imageSet = x.IdentifyNose();

                Debug.WriteLine("Number if Left Eyes: " + imageSet.Count);

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }



                    }

                    bmp.Save("c:\\bmp4.bmp");
                }
            }
        }

        [TestMethod]
        public void TestMethod7()
        {
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                FaceFeatureIdentification x = new FaceFeatureIdentification(img);

                List<Rectangle> imageSet = x.IndentifyLeftEar();

                Debug.WriteLine("Number if Left Eyes: " + imageSet.Count);

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }



                    }

                    bmp.Save("c:\\bmp5.bmp");
                }
            }
        }

        [TestMethod]
        public void TestMethod8()
        {
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                FaceFeatureIdentification x = new FaceFeatureIdentification(img);

                List<Rectangle> imageSet = x.IndentifyRightEar();

                Debug.WriteLine("Number if Left Eyes: " + imageSet.Count);

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height))
                {
                    using (System.Drawing.Graphics grp = System.Drawing.Graphics.FromImage(bmp))
                    {
                        grp.DrawImage(img, new System.Drawing.Point(0, 0));

                        foreach (var item in imageSet)
                        {
                            grp.DrawRectangle(Pens.Black, item);
                        }



                    }

                    bmp.Save("c:\\bmp6.bmp");
                }
            }
        }
    }
}
