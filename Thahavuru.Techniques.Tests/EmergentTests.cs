using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thahavuru.Techniques.WebServiceMethods;
using Thahavuru.Resources.ViewModels;
using Emgu.CV;
using Emgu.CV.Structure;

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
            userInterfaceModel.SearchingPerson = new PersonVM() { FaceofP = new Face() { FaceImage = new Image<Gray, byte>(@"D:\Users\Diyoda Sajjana\Education\My Books\CSE\Uni\Mora\FYP\src\WCF\Thahavuru.Libraries\Thahavuru.Techniques.Tests\bin\Debug\40.jpg") } };
            //userInterfaceModel.SearchingPerson.FaceofP.FaceImage = new Image<Gray, byte>(@"D:\Users\Diyoda Sajjana\Education\My Books\CSE\Uni\Mora\FYP\src\WCF\Thahavuru.Libraries\Thahavuru.Techniques.Tests\bin\Debug\40.jpg");
            var test = new FaceMatchAdapter();
            test.FaceMatch(ref userInterfaceModel);

            foreach (var item in userInterfaceModel.SearchingPerson.SearchTrakKeeper)
	        {
		        Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine("-----");
	        }
            Console.Read();
        }
    }
}
