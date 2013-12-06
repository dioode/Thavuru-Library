using System;
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
            userInterfaceModel.SearchingPerson.FaceofP.FaceImage = new Image<Gray, byte>(@"D:\1.jpg");
            
            var test = new FaceMatchAdapter();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            test.FaceMatch(ref userInterfaceModel);
            sw.Stop();
            Debug.WriteLine("Elapsed={0}", sw.ElapsedMilliseconds);
            

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
