using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thahavuru.Techniques.FaceRecT;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.Util;
using System.Diagnostics;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class UnitTest1{
        [TestMethod]
        public void TestMethod1()
        {
            
            using (Image img = System.Drawing.Image.FromFile("40.jpg"))
            {
                CascadeConfig config = new CascadeConfig(img.Width, 25, 1.4, 0, @"haarcascade_frontalface_default.xml");

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

    }
}
