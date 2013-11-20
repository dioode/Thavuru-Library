﻿using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.DataAccessLayer.EDMX;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.DataAccessLayer
{
    public class DataAccessSingleton
    {
        public TrainingSet GetTraingSet(int classAttributeId) 
        {
            TrainingSet TSet = new TrainingSet();
            TSet.trainingList = new List<Image<Gray,byte>>();
            TSet.labelList = new List<int>();
            
            using (var ctx = new FaceRecEFEntities())
            {
                var TrainSet =
                    (from c in ctx.IndClasses join i in ctx.ClassElementImages
                    on c.ClassId equals i.Class_ClassId
                    where c.Class_Attrubute_Id == classAttributeId
                    select new
                    {
                        ClassNumber = c.ClassNumber,
                        image = i.Feature_img_uri
                    }).ToList();

                if (TrainSet.Count != 0) 
                {
                    foreach (var t in TrainSet) 
                    {
                        TSet.labelList.Add((int)t.ClassNumber);
                        string imgUri = @"C:\ImageDB\" + (string)t.image;
                        TSet.trainingList.Add(new Image<Gray, byte>(imgUri));
                    }
                }

            }
            return TSet;
        }

        public PersonVM GetPersonByID(int personId)
        {
            PersonVM PersonM = new PersonVM();


            using (var ctx = new FaceRecEFEntities())
            {
                var person = (from s in ctx.People
                              where s.Id == personId
                              select s).FirstOrDefault<Person>();

                if (person != null)
                {
                    PersonM.Id = (int)person.Id;
                    PersonM.Name = (string)person.Name;
                    //PersonM.N
                    PersonM.Address = (string)person.Address;
                }
            }

            return PersonM;
        }

        public PersonVM GetPersonByNIC(string nicString)
        {
            PersonVM PersonM = new PersonVM();

            using (var ctx = new FaceRecEFEntities())
            {
                var person = (from s in ctx.People
                              where s.UserID == nicString
                              select s).FirstOrDefault<Person>();

                if (person != null)
                {
                    PersonM.Id = (int)person.Id;
                    PersonM.Name = (string)person.Name;
                    PersonM.Address = (string)person.Address;
                }
            }

            return PersonM;
        }

        public List<PersonVM> GetPersonByName(string name)
        {
            List<PersonVM> PersonM = new List<PersonVM>();

            using (var ctx = new FaceRecEFEntities())
            {
                var persons = (from s in ctx.People
                               where s.Name == name
                               select s).ToList();

                if (persons != null)
                {
                    foreach(var p in persons){
                        PersonVM pM = new PersonVM();
                        pM.Id = (int)p.Id;
                        pM.Name = (string)p.Name;
                        pM.Address = (string)p.Address;
                        PersonM.Add(pM);
                    }
                }
            }
            return PersonM;
        }

        public TrainingSet GetTraingSet(List<int> personIdSet)
        {
            //return dataAccess
            return new TrainingSet();
        }
    }
}
