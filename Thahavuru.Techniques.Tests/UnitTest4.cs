using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thahavuru.Techniques.WebServiceMethods;
using Thahavuru.Resources.ViewModels;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Thahavuru.Techniques.Tests
{
    [TestClass]
    public class UnitTest4
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
        }
    }
}
