﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thahavuru.Techniques.WebServiceMethods;
using Thahavuru.Resources.ViewModels;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class EmergentTests
    {  
        [TestMethod]
        public void FaceRecogntion()
        {
            var userInterfaceModel= new UserInterfaceModel();
            userInterfaceModel.Next = true;
            userInterfaceModel.PageNumber = 1;
            userInterfaceModel.SearchingPerson.FaceofP.FaceImage = new Image<Gray, byte>(@"D:\Users\Diyoda Sajjana\Education\My Books\CSE\Uni\Mora\FYP\src\WCF\Thahavuru.Libraries\Thahavuru.Techniques.Tests\bin\Debug\40.jpg");
            var test = new FaceMatchAdapter();
            test.FaceMatch(ref userInterfaceModel);
            for (int i = 2; i < 3; i++)
            {
                userInterfaceModel.PageNumber = i;
                test.FaceMatch(ref userInterfaceModel);

                foreach (var itemSet in userInterfaceModel.SearchingPerson.MatchedFaceIdSet)
                {
                    foreach (var item in itemSet.Value)
                    {
                        Debug.Write(item + " ,");
                    }
                    Debug.WriteLine("----------");
                }
            }
            
            
        }
    }
}
