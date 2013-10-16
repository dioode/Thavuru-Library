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
using Thahavuru.Techniques.ViewModels;

namespace Thahavuru.Techniques.ClassificationT
{
    public class SVMT
    {
        public float SVMTT(Face probeImage, TrainingSet tSet)
        {
            int imageLength = probeImage.FaceImage.Width*probeImage.FaceImage.Height;

            Matrix<float> trainData = new Matrix<float>(0, imageLength);//matrix for holding image values
            Matrix<float> trainClasses = new Matrix<float>(1, 1);// one class for each image

            #region Store training images in Matrix

            for (int i = 0; i < tSet.trainingList.Count; i++)
            {
                Matrix<float> mtrx = new Matrix<float>(tSet.trainingList[i].Height, tSet.trainingList[i].Width);
                CvInvoke.cvConvert(tSet.trainingList[i], mtrx);

                Matrix<float> temp = new Matrix<float>(1, imageLength);
                Matrix<float> tempClass = new Matrix<float>(1, 1);

                for (int j = 0; j < mtrx.Height; j++)
                {
                    for (int k = 0; k < mtrx.Width; k++)
                    {
                        temp[0, ((j * mtrx.Width) + k)] = mtrx[j, k];
                    }
                }
                tempClass[0, 0] = tSet.labelList[i];
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

            Matrix<float> sampleImg = new Matrix<float>(probeImage.FaceImage.Height, probeImage.FaceImage.Width);
            CvInvoke.cvConvert(probeImage.FaceImage, sampleImg);
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

                return response;
            }
        }
    }
}
