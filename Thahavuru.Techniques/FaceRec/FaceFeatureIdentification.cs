using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Techniques.FaceRecT;
using Thahavuru.Techniques.ViewModels;

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
        public Face IdentifyFace(Image faceImage)
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

        private Rectangle[] IndentifyLeftEye() 
        {
            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width/2, faceImage.Width/4, 1.5, 0, @"../Resources/Cascades/LEyes.xml"));

        }

        private Rectangle[] IndentifyRightEye()
        {
            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.5, 0, @"../../Resources/Cascades/REyes.xml"));

        }

        private Rectangle[] IndentifyRightEar()
        {
            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.5, 0, @"../../Resources/Cascades/REars.xml"));

        }

        private Rectangle[] IndentifyLeftEar()
        {
            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.5, 0, @"../../Resources/Cascades/LEars.xml"));

        }

        private Rectangle[] IdentifyNose() 
        {
            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.5, 0, @"../../Resources/Cascades/Noses1.xml"));

        }

        private Rectangle[] IndetifyMouth() 
        {
            return new HaarCascade_().ObjectDetection(new Bitmap(faceImage), new CascadeConfig(faceImage.Width / 2, faceImage.Width / 4, 1.5, 0, @"../../Resources/Cascades/Mouth.xml"));

        }
    }
}
