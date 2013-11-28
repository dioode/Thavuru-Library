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

        public FaceAttributeHiearachy GetFaceAttributeHierarchy()
        {
            FaceAttributeHiearachy faceAttributeHiearachy = new FaceAttributeHiearachy();
            faceAttributeHiearachy.OrderedFaceAttributeSet = new List<FaceAttribute>();
            using (var ctx = new FaceRecEFEntities()) 
            {
                var hierarchy = (from ah in ctx.FaceAttributeHierarchies
                                 join a in ctx.Class_Attrubute
                                     on ah.ClassAttribute_AttId equals a.CAttributeId
                                 select new
                                 {
                                     AttributeId = a.CAttributeId,
                                     Name = a.Name,
                                     IsBiometric = a.IsBiometric,//IsBiometic,
                                     NoOfClasses = a.NumberOfClasses,
                                     ClassificationTechnique = a.ClassificationTechnique,
                                     LevelNo = ah.LevelNo
                                 }).ToList().OrderBy(x => x.LevelNo);

                var technique = (from tech in ctx.SystemConfigVariables where tech.VariableName == "MATCHING_TECHNIQUE" select tech.VariableValue).FirstOrDefault<string>();
                
                foreach (var fah in hierarchy) 
                {
                    FaceAttribute fa = new FaceAttribute();
                    fa.AttributeId = fah.AttributeId;
                    fa.ClassificationTechnique = fah.ClassificationTechnique;
                    fa.IsBiometric = (bool)(fah.IsBiometric == null ? false:fah.IsBiometric)  ;
                    fa.NumberOfClasses = (int)(fah.NoOfClasses == null? 0:fah.LevelNo);
                    fa.Name = fah.Name;
                    faceAttributeHiearachy.OrderedFaceAttributeSet.Add(fa);
                }
                faceAttributeHiearachy.FaceMatchingTechnique = technique.ToString();
            }
            
            return faceAttributeHiearachy;
        }

        public TrainingSet GetAllNarrowdownFaceImageSet(PersonVM searchingPerson, int pageNumber) 
        {
            var wantedSearchingTrack = searchingPerson.SearchTrakKeeper[pageNumber-1];

            using (var ctx = new FaceRecEFEntities())
            {
                var faceImageSet = ctx.Images.AsQueryable();
                foreach (var attrubuteLocation in wantedSearchingTrack)
                {
                    var personIdSetForCurrentAttrubute = ctx.People.Join(
                                ctx.PersonalFeatureSets,x =>x.Id,
                                y => y.Person_Id,
                                (x,y) => new { personId =x.Id, attributeId = y.IndClass.Class_Attrubute_Id, classNumber = y.IndClass.ClassNumber})
                                .Where(s => s.attributeId == searchingPerson.FaceofP.FaceAttributes[attrubuteLocation[0]-1].AttributeId && s.classNumber == attrubuteLocation[1]);

                    faceImageSet = faceImageSet.Where(x => personIdSetForCurrentAttrubute.Select(t => t.personId).Contains((int)x.Person_Id)) ;
                }

                var trainingSet = new TrainingSet();
                
                foreach (var item in faceImageSet)
	            {
		            trainingSet.trainingImageURIList.Add(item.Image_uri);
                    trainingSet.trainingList.Add(new Image<Gray, byte>(@"C:\ImageDB\" +item.Image_uri));
                    trainingSet.labelList.Add(item.Image_Id);
	            }

                return trainingSet;
            }

        }

    }
}
