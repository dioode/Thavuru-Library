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
            TrainingSet tset = DAS.GetTraingSet(4);

            Assert.AreEqual(lable.ToString(), tset.labelList[1].ToString(), true);
        }

        [TestMethod]
        public void GetFaceAttributeHierarchyTest() 
        {
            DataAccessSingleton DAS = new DataAccessSingleton();
            FaceAttributeHiearachy tset = DAS.GetFaceAttributeHierarchy();
        }

        [TestMethod]
        public void GetAllNarrowdownFaceImageSetTest() 
        {
            DataAccessSingleton DAS = new DataAccessSingleton();

            PersonVM person = new PersonVM();
            //person.SearchTrakKeeper = new List<List<List<int>>>();
            
            List<List<int>> list = new List<List<int>>();
            list.Add(new List<int>() { 1, 2 });
            list.Add(new List<int>() { 2, 2 });
            list.Add(new List<int>() { 3, 2 });

            person.SearchTrakKeeper.Add(list);

            TrainingSet tset = DAS.GetAllNarrowdownFaceImageSet(person, 1);
        }

        [TestMethod]
        public void GetAllAttributesTest() 
        {
            DataAccessSingleton dAS = new DataAccessSingleton();
            dAS.GetAllAttributes();
        }

        [TestMethod]
        public void AddNewAttributeToHierarchyTest() 
        {
            DataAccessSingleton das = new DataAccessSingleton();

            das.AddNewAttributeToHierarchy(3);

        }

        [TestMethod]
        public void RemoveAttributeFromHierarchyTest() 
        {
            DataAccessSingleton das = new DataAccessSingleton();
            das.RemoveAttributeFromHierarchy(3);
        }

        [TestMethod]
        public void MoveUpHierarchyTest() 
        {
            DataAccessSingleton das = new DataAccessSingleton();
            das.MoveUpHierarchy(2);
        }

        [TestMethod]
        public void MoveDownHierarchyTest() 
        {
            DataAccessSingleton das = new DataAccessSingleton();
            das.MoveDownHierarchy(2);
        }
    }
}
