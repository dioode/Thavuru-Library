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
        public void EmergentTesting_FaceRecogntion()
        {
            var userInterfaceModel= new UserInterfaceModel();
            userInterfaceModel.Next = true;
            userInterfaceModel.PageNumber = 1;
            userInterfaceModel.SearchingPerson.FaceofP.FaceImage = new Image<Gray, byte>(@"C:\ImageDB\PersonImages\User (10).jpg");
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

            for (int i = 2; i < 5; i++)
            {
                userInterfaceModel.Next = true;
                userInterfaceModel.PageNumber = i;
                test.FaceMatch(ref userInterfaceModel);

                var x = userInterfaceModel.SearchingPerson.MatchedFaceIdSet[i];
                
                foreach (var item in x)
                {
                    Debug.Write(item + " ,");
                }
                Debug.WriteLine("----------");
                
            }

            for (int i = 4; i >0 ; i--)
            {
                userInterfaceModel.Back = true;
                userInterfaceModel.PageNumber = i;
                test.FaceMatch(ref userInterfaceModel);

                var x = userInterfaceModel.SearchingPerson.MatchedFaceIdSet[i];

                foreach (var item in x)
                {
                    Debug.Write(item + " ,");
                }
                Debug.WriteLine("----------");

            }
            
        }
    }
}
