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
        public void DataAcessSingleton_GetPersonByIDTest()
        {
            int PersonId = 2;
            string Name = "User (2)";
            //string Address = "ADDRESS (2)";

            var dAccess = DataAccessSingleton.Instance;

            PersonVM person = dAccess.GetPersonByID(PersonId);

            Assert.AreEqual(Name, person.Name,true);

        }

        [TestMethod]
        public void DataAcessSingleton_GetPersonByNICTest()
        {
            
            string nic = "NIC (3)";

            string Address = "ADDRESS (3)";

            DataAccessSingleton dAccess = DataAccessSingleton.Instance;

            PersonVM person = dAccess.GetPersonByNIC(nic);
            //asdsdfsdfsf
            Assert.AreEqual(Address, person.Address, true);
        }

        [TestMethod]
        public void DataAcessSingleton_GetPersonByNameTest()
        {
            
            string Name = "User (4)";
            string address = "ADDRESS (4)";

            DataAccessSingleton dAccess = DataAccessSingleton.Instance;

            List<PersonVM> persons = dAccess.GetPersonByName(Name);//GetPersonByName

            Assert.AreEqual(address, persons[0].Address, true);
        }

        [TestMethod]
        public void DataAcessSingleton_GetTraingSetTest() 
        {
            int lable = 1;

            DataAccessSingleton dAccess = DataAccessSingleton.Instance;
            TrainingSet tset = dAccess.GetTraingSet(4);

            Assert.AreEqual(lable.ToString(), tset.labelList[1].ToString(), true);
        }

        [TestMethod]
        public void DataAcessSingleton_GetFaceAttributeHierarchyTest() 
        {
            DataAccessSingleton dAccess = DataAccessSingleton.Instance;
            FaceAttributeHiearachy tset = dAccess.GetFaceAttributeHierarchy();
        }

        [TestMethod]
        public void DataAcessSingleton_GetAllNarrowdownFaceImageSetTest() 
        {
            DataAccessSingleton dAccess = DataAccessSingleton.Instance;

            PersonVM person = new PersonVM();
            //person.SearchTrakKeeper = new List<List<List<int>>>();
            
            List<List<int>> list = new List<List<int>>();
            list.Add(new List<int>() { 1, 2 });
            list.Add(new List<int>() { 2, 2 });
            list.Add(new List<int>() { 3, 2 });

            person.SearchTrakKeeper.Add(list);

            TrainingSet tset = dAccess.GetAllNarrowdownFaceImageSet(person, 1);
        }

        [TestMethod]
        public void GetAllAttributesTest() 
        {
            DataAccessSingleton dAS = DataAccessSingleton.Instance;
            dAS.GetAllAttributes();
        }

        [TestMethod]
        public void AddNewAttributeToHierarchyTest() 
        {
            DataAccessSingleton das = DataAccessSingleton.Instance;

            das.AddNewAttributeToHierarchy(3);

        }

        [TestMethod]
        public void RemoveAttributeFromHierarchyTest() 
        {
            DataAccessSingleton das = DataAccessSingleton.Instance;
            das.RemoveAttributeFromHierarchy(3);
        }

        [TestMethod]
        public void MoveUpHierarchyTest() 
        {
            DataAccessSingleton das = DataAccessSingleton.Instance;
            das.MoveUpHierarchy(2);
        }

        [TestMethod]
        public void MoveDownHierarchyTest() 
        {
            DataAccessSingleton das = DataAccessSingleton.Instance;
            das.MoveDownHierarchy(2);
        }
    }
}
