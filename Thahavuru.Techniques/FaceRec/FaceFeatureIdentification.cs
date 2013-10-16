using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.FaceRecT;
using Thahavuru.Techniques.ViewModels;
using Thahavuru.Techniques.ImageProcessingT;

namespace Thahavuru.Techniques.FaceRec
{
    public class FaceFeatureIdentification
    {
        Image faceImage;
        ICascade cascade; 

        public FaceFeatureIdentification(Image faceImage)
        {
            this.faceImage = faceImage;
            cascade = new HaarCascade_();

        }

        public GeometricFace IdentifyFace(Image faceImage)
        {
            var unresolvedFace = new FaceUnresolved();
            unresolvedFace.LEyeSet = IndentifyLeftEye();
            unresolvedFace.REyeSet = IndentifyLeftEye();
            unresolvedFace.LEarSet = IndentifyLeftEye();
            unresolvedFace.REarSet = IndentifyLeftEye();
            unresolvedFace.MouthSet = IndentifyLeftEye();
            unresolvedFace.NoseSet = IndentifyLeftEye();
            unresolvedFace.ImageWidth = faceImage.Width;
            unresolvedFace.ImageHeight = faceImage.Height;


            return FaceRecognitionPolicy.Policy(unresolvedFace);
        }

        public List<Rectangle> IndentifyLeftEye() 
        {
            //Bitmap imageBitmap = new Bitmap(faceImage);
            //Bitmap croppedFaceImage = imageBitmap.Crop(0, 0, faceImage.Width / 2, faceImage.Height/2);
            //croppedFaceImage.Save("c:\\bmpss.bmp");

            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.3, 2, @"../../../Thahavuru.Techniques/Resources/Cascades/LEyes.xml")).ToList();
                    
        }

        public List<Rectangle> IndentifyRightEye()
        {
            //Bitmap imageBitmap = new Bitmap(faceImage);
            //Bitmap croppedFaceImage = imageBitmap.Crop(faceImage.Width/2, 0, faceImage.Width / 2, faceImage.Height);
            //croppedFaceImage.Save("c:\\bmpss1.bmp");
            
            var collection = new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 8, 1.3, 2, @"../../../Thahavuru.Techniques/Resources/Cascades/REyes.xml")).ToList();
            //var list = new List<Rectangle>();
            //foreach (var item in collection)
            //{
            //    list.Add(new Rectangle(faceImage.Width/2 +item.X, item.Y, item.Width,item.Height));
            //}
            //return list;
            return collection;
        }

        public List<Rectangle> IndentifyRightEar()
        {
            //Bitmap imageBitmap = new Bitmap(faceImage);
            //Bitmap croppedFaceImage = imageBitmap.Crop(faceImage.Width / 2, 0, faceImage.Width / 2, faceImage.Height);
            //croppedFaceImage.Save("c:\\bmpss3.bmp");

            var collection = new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.3, 2, @"../../../Thahavuru.Techniques/Resources/Cascades/REars.xml")).ToList();
            //var list = new List<Rectangle>();
            //foreach (var item in collection)
            //{
            //    list.Add(new Rectangle(faceImage.Width / 2 + item.X, item.Y, item.Width, item.Height));
            //}
            //return list;
            return collection;
        }

        public List<Rectangle> IndentifyLeftEar()
        {
            //Bitmap imageBitmap = new Bitmap(faceImage);
            //Bitmap croppedFaceImage = imageBitmap.Crop(0, 0, faceImage.Width / 2, faceImage.Height);
            //croppedFaceImage.Save("c:\\bmpss4.bmp");

            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.3, 2, @"../../../Thahavuru.Techniques/Resources/Cascades/LEars.xml")).ToList();

        }

        public List<Rectangle> IdentifyNose() 
        {
            //Bitmap imageBitmap = new Bitmap(faceImage);
            //Bitmap croppedFaceImage = imageBitmap.Crop(faceImage.Width, faceImage.Height/4, faceImage.Width / 2, faceImage.Height / 2);
            //croppedFaceImage.Save("c:\\bmpss5.bmp");

            var collection = new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width, faceImage.Width / 5, 1.2, 2, @"../../../Thahavuru.Techniques/Resources/Cascades/Nose2.xml")).ToList();
            //var list = new List<Rectangle>();
            //foreach (var item in collection)
            //{
            //    list.Add(new Rectangle(faceImage.Width / 4 + item.X, item.Y, item.Width, item.Height));
            //}
            //return list;
            return collection;
        }

        public List<Rectangle> IndetifyMouth() 
        {
            //Bitmap imageBitmap = new Bitmap(faceImage);
            //Bitmap croppedFaceImage = imageBitmap.Crop(0, faceImage.Height/2, faceImage.Width, faceImage.Height/2);
            //croppedFaceImage.Save("c:\\bmpss7.bmp");

            var collection = new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.3, 2, @"../../../Thahavuru.Techniques/Resources/Cascades/Mouth.xml")).ToList();
            //var list = new List<Rectangle>();
            //foreach (var item in collection)
            //{
            //    list.Add(new Rectangle(item.X, faceImage.Height / 2 + item.Y, item.Width, item.Height));
            //}
            //return list;
            return collection;
        }
    }
}
