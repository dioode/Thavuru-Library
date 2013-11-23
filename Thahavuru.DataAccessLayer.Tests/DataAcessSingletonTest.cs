using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thahavuru.DataAccessLayer;
using Thahavuru.DataAccessLayer.EDMX;
using Thahavuru.Resources.ViewModels;
using System.Collections.Generic;

namespace Thahavuru.DataAccessLayer.Tests
{
    [TestClass]
    public class DataAcessSingletonTest
    {
        [TestMethod]
        public void GetPersonByIDTest()
        {
            int PersonId = 2;
            string Name = "User (2)";
            //string Address = "ADDRESS (2)";

            DataAccessSingleton DAS = new DataAccessSingleton();

            PersonVM person = DAS.GetPersonByID(PersonId);

            Assert.AreEqual(Name, person.Name,true);

        }

        [TestMethod]
        public void GetPersonByNICTest()
        {
            int PersonId = 3;
            string NIC = "NIC (3)";

            string Address = "ADDRESS (3)";

            DataAccessSingleton DAS = new DataAccessSingleton();

            PersonVM person = DAS.GetPersonByNIC(NIC);
            //asdsdfsdfsf
            Assert.AreEqual(Address, person.Address, true);
        }

        [TestMethod]
        public void GetPersonByNameTest()
        {
            int PersonId = 3;
            string Name = "User (4)";
            string Address = "ADDRESS (4)";

            DataAccessSingleton DAS = new DataAccessSingleton();

            List<PersonVM> persons = DAS.GetPersonByName(Name);//GetPersonByName

            Assert.AreEqual(Address, persons[0].Address, true);
        }

        [TestMethod]
        public void GetTraingSetTest() 
        {
            int lable = 1;

            DataAccessSingleton DAS = new DataAccessSingleton();
            TrainingSet tset = DAS.GetTraingSet(2);

            Assert.AreEqual(lable.ToString(), tset.labelList[1].ToString(), true);
        }

        [TestMethod]
        public void GetFaceAttributeHierarchyTest() 
        {
            DataAccessSingleton DAS = new DataAccessSingleton();
            FaceAttributeHiearachy tset = DAS.GetFaceAttributeHierarchy();
        }

    }
}
