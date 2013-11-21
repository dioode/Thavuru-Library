﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Thahavuru.Techniques.ClassificationT;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.Classification;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class UnitTest3
    {
        private static TrainingSet Data()
        {
            List<string> trainName = new List<string>();
            List<Image<Gray, byte>> imageList = new List<Image<Gray, byte>>();
            List<int> labelList = new List<int>();

            int j = 0;
            string[] files = System.IO.Directory.GetFiles(@"H:\FYP\images\images\Male", "*.jpg");

            while (j < 80)
            {
                labelList.Add(0);
                trainName.Add("face_" + j.ToString());
                imageList.Add(new Image<Gray, byte>(@files[j]));//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                j++;
            }

            string[] files2 = System.IO.Directory.GetFiles(@"H:\FYP\images\images\Female", "*.jpg");

            while (j < 160)
            {
                labelList.Add(1);
                trainName.Add("face2_" + j.ToString());
                imageList.Add(new Image<Gray, byte>(@files2[j - 80]));//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                j++;
            }

            TrainingSet tset = new TrainingSet();
            tset.labelList = labelList;
            tset.trainingList = imageList;
            return tset;
        }

        [TestMethod]
        public void LDATest() 
        {
            TrainingSet tset = Data();

            IFace iface = new Face();
            iface.FaceImage = new Image<Gray, byte>(@"H:\FYP\images\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            LDA lda = new LDA();
            FaceRecognizer.PredictionResult result = lda.FLDT(iface, tset);
        }

        [TestMethod]
        public void PCATest() 
        {
            TrainingSet tset = Data();

            IFace iface = new Face();
            iface.FaceImage = new Image<Gray, byte>(@"H:\FYP\images\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            PCA pca = new PCA();
            List<int> result = pca.PCAT(iface, tset);
        }

        [TestMethod]
        public void SVMTest()
        {
            TrainingSet tset = Data();

            IFace iface = new Face();
            iface.FaceImage = new Image<Gray, byte>(@"H:\FYP\images\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            SVMT svm = new SVMT();
            int result = svm.SVMTT(iface, tset);
        }

        [TestMethod]
        public void LDAForMultipleResults() 
        {
            TrainingSet tset = Data();

            IFace iface = new Face();
            iface.FaceAttributes = new List<FaceAttribute>();
            iface.FaceImage = new Image<Gray, byte>(@"H:\FYP\images\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            PersonVM person = new PersonVM();
            person.FaceofP = iface;
            person.MatchedFaceIdSet = new Dictionary<int,List<int>>();

            LDAClassifier_GC lda = new LDAClassifier_GC();

            lda.RecognizeGC_LDA(ref person, tset, 10, 1);
        }

        [TestMethod]
        public void LDAForMultipleClassify()
        {
            TrainingSet tset = Data();

            IFace iface = new Face();
            iface.FaceAttributes = new List<FaceAttribute>();
            iface.FaceImage = new Image<Gray, byte>(@"H:\FYP\images\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            PersonVM person = new PersonVM();
            person.FaceofP = iface;

            LDAClassifier_GC lda = new LDAClassifier_GC();
            //ClassifyGC_LDA
            FaceAttribute attribute = new FaceAttribute();
            attribute.NumberOfClasses = 2;
            attribute.SortedClasses = new List<int>();
            
            //attribute.SortedClasses.Add(1);

            lda.ClassifyGC_LDA(ref person, tset, attribute);
        }

        [TestMethod]
        public void PCAForMultipleResults()
        {
            TrainingSet tset = Data();

            IFace iface = new Face();
            iface.FaceAttributes = new List<FaceAttribute>();
            iface.FaceImage = new Image<Gray, byte>(@"H:\FYP\images\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            PersonVM person = new PersonVM();
            person.FaceofP = iface;
            person.MatchedFaceIdSet = new Dictionary<int, List<int>>();

            PCAClassifier_GC pca = new PCAClassifier_GC();

            pca.RecognizeGC_PCA(ref person, tset, 10, 1);
        }

        [TestMethod]
        public void PCAForMultipleClassify()
        {
            TrainingSet tset = Data();

            IFace iface = new Face();
            iface.FaceAttributes = new List<FaceAttribute>();
            iface.FaceImage = new Image<Gray, byte>(@"H:\FYP\images\images\cropped-man-cap-1369042172067.jpg");//.Resize(imageSize, imageSize, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            PersonVM person = new PersonVM();
            person.FaceofP = iface;

            PCAClassifier_GC pca = new PCAClassifier_GC();
            //ClassifyGC_LDA
            FaceAttribute attribute = new FaceAttribute();
            attribute.NumberOfClasses = 2;
            attribute.SortedClasses = new List<int>();

            attribute.SortedClasses.Add(1);

            pca.ClassifyGC_PCA(ref person, tset, attribute);
        }

    }
}
