using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Thahavuru.Techniques.Utils;

namespace Thahavuru.Techniques.ClassificationT
{
    class SVM2
    {
        private static void svmImage()
        {
            List<string> trainName = new List<string>();
            List<Image<Gray, byte>> imageList = new List<Image<Gray, byte>>();
            List<int> labelList = new List<int>();

            DataAccessUtil.GetImageData(trainName, imageList, labelList);
            Image<Gray, byte> testImage = new Image<Gray, byte>(@"D:\My Work\Testing Projects\Thahavuru\LDA\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //int trainSampleCount = 150;
            int imageLength = 252 * 336;

            Matrix<float> trainData = new Matrix<float>(0, imageLength);//matrix for holding image values
            Matrix<float> trainClasses = new Matrix<float>(1, 1);// one class for each image

            #region Store training images in Matrix

            for (int i = 0; i < imageList.Count; i++)
            {
                Matrix<float> mtrx = new Matrix<float>(imageList[i].Height, imageList[i].Width);
                CvInvoke.cvConvert(imageList[i], mtrx);

                Matrix<float> temp = new Matrix<float>(1, imageLength);
                Matrix<float> tempClass = new Matrix<float>(1, 1);

                for (int j = 0; j < mtrx.Height; j++)
                {
                    for (int k = 0; k < mtrx.Width; k++)
                    {
                        temp[0, ((j * mtrx.Width) + k)] = mtrx[j, k];
                    }
                }
                tempClass[0, 0] = labelList[i];
                if (i == 0)
                {
                    trainData = temp;
                    trainClasses = tempClass;
                }
                else
                {
                    trainData = trainData.ConcateVertical(temp);
                    trainClasses = trainClasses.ConcateHorizontal(tempClass);
                }
            }

            #endregion

            #region Sample image stored in Matrix

            Matrix<float> sampleImg = new Matrix<float>(testImage.Height, testImage.Width);
            CvInvoke.cvConvert(testImage, sampleImg);
            Matrix<float> sample = new Matrix<float>(1, imageLength);

            for (int j = 0; j < sampleImg.Height; j++)
            {
                for (int k = 0; k < sampleImg.Width; k++)
                {
                    sample[0, ((j * sampleImg.Width) + k)] = sampleImg[j, k];
                }
            }

            #endregion

            using (SVM model = new SVM())
            {
                SVMParams p = new SVMParams();
                p.KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR;
                p.SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC;
                p.C = 1;
                p.TermCrit = new MCvTermCriteria(100, 0.00001);

                bool trained = model.TrainAuto(trainData, trainClasses, null, null, p.MCvSVMParams, 5);

                float response = model.Predict(sample);
            }
        }
    }
}
