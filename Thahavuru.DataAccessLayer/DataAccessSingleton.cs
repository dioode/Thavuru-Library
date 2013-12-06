using Emgu.CV;
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
                    fa.NumberOfClasses = (int)(fah.NoOfClasses == null? 0:fah.NoOfClasses);
                    fa.Name = fah.Name;

                    var indClasses = (from i in ctx.IndClasses
                                    where i.Class_Attrubute_Id == fa.AttributeId
                                    select new { name = i.Name, classNumber = i.ClassNumber }).ToList();
                    if (indClasses != null) 
                    {
                        foreach (var indClass in indClasses)
                        {
                            fa.ClassesInOrder.Add(new IndividualClass() { ClassNumber = (int)indClass.classNumber, Name = indClass.name });
                        }
                    }

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
                var faceImageSet = ctx.Images.ToList();
                foreach (var attrubuteLocation in wantedSearchingTrack)
                {
                    int currentAttrubuteID = searchingPerson.FaceofP.FaceAttributes[attrubuteLocation[0] - 1].AttributeId;
                    int classNumberForCurrentAttribute = attrubuteLocation[1];
                    var personIdSetForCurrentAttrubute = ctx.People.Join(
                                ctx.PersonalFeatureSets, x => x.Id,
                                y => y.Person_Id,
                                (x, y) => new { personId = x.Id, attributeId = y.IndClass.Class_Attrubute_Id, classNumber = y.IndClass.ClassNumber }).ToList()
                                .Where(s => s.attributeId == currentAttrubuteID && s.classNumber == classNumberForCurrentAttribute).ToList();

                    faceImageSet = faceImageSet.Where(x => personIdSetForCurrentAttrubute.Select(t =>t.personId).Contains((int)x.Person_Id)).ToList();
                }

                var trainingSet = new TrainingSet();
                
                foreach (var item in faceImageSet)
	            {
		            trainingSet.trainingImageURIList.Add(item.Image_uri);
                    trainingSet.trainingList.Add(new Image<Gray, byte>(@"C:\ImageDB\PersonImages\" + item.Image_uri));
                    trainingSet.labelList.Add((int)item.Person_Id);
	            }

                return trainingSet;

            }

        }

        public List<FaceAttribute> GetAllAttributes() 
        {
            List<FaceAttribute> attributes = null;
            using (var ctx = new FaceRecEFEntities())
            {
                var attList = (from a in ctx.Class_Attrubute
                               select new
                               {
                                   attributeId = a.CAttributeId,
                                   name = a.Name,
                                   isBiometric = a.IsBiometric,
                                   noOfClasses = a.NumberOfClasses,
                                   classificationTechnique = a.ClassificationTechnique,
                                   
                               }).ToList();
                if (attList != null) 
                {
                    attributes = new List<FaceAttribute>();
                    foreach (var item in attList)
                    {
                        FaceAttribute att = new FaceAttribute();
                        att.AttributeId = item.attributeId;
                        att.Name = item.name;
                        att.IsBiometric = (bool) item.isBiometric;
                        att.NumberOfClasses = Convert.ToInt32(item.noOfClasses);
                        att.ClassificationTechnique = item.classificationTechnique;
                        var iClasses = (from i in ctx.IndClasses where i.Class_Attrubute_Id == item.attributeId select new
                                        {
                                            id = i.ClassId,
                                            name = i.Name,
                                            classNumber = i.ClassNumber
                                        }).ToList();
                        foreach (var c in iClasses)
                        {
                            IndividualClass iC = new IndividualClass();
                            iC.Name = c.name;
                            iC.ClassNumber = Convert.ToInt32(c.classNumber);
                            iC.Id = c.id;
                            att.ClassesInOrder.Add(iC);
                        }
                        attributes.Add(att);
                    }
                }
            }

            return attributes;
        }

        public bool AddNewAttributeToHierarchy(int attId) 
        {
            using (var ctx = new FaceRecEFEntities())
            {
                var hierarchy = (from ah in ctx.FaceAttributeHierarchies
                                 join a in ctx.Class_Attrubute
                                     on ah.ClassAttribute_AttId equals a.CAttributeId
                                 select new
                                 {
                                     LevelNo = ah.LevelNo
                                 }).ToList().OrderBy(x => x.LevelNo);

                int lastLevel = (int)hierarchy.Last().LevelNo;

                FaceAttributeHierarchy fHierarchy = new FaceAttributeHierarchy();
                fHierarchy.ClassAttribute_AttId = attId;
                fHierarchy.LevelNo = lastLevel + 1;

                ctx.FaceAttributeHierarchies.Add(fHierarchy);
                try
                {
                    ctx.SaveChanges();
                    return(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return false;
        }

        public bool RemoveAttributeFromHierarchy(int attId) 
        {
            using (var ctx = new FaceRecEFEntities())
            {
                FaceAttributeHierarchy hierarchy = ctx.FaceAttributeHierarchies.Where(a => a.ClassAttribute_AttId == attId).FirstOrDefault();
                ctx.FaceAttributeHierarchies.Remove(hierarchy);
                try
                {
                    ctx.SaveChanges();
                    var newHierarchy = ctx.FaceAttributeHierarchies.Where(a => a.ClassAttribute_AttId == a.ClassAttribute_AttId).OrderBy(x => x.LevelNo).ToList(); 
                    
                    for (int i = 0; i < newHierarchy.Count; i++)
                    {
                        if (newHierarchy[i].LevelNo != (i + 1))
                        {
                            newHierarchy[i].LevelNo = i + 1;
                        }
                    }
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
            return false;
        }

        public bool MoveUpHierarchy(int attId) 
        {
            using (var ctx = new FaceRecEFEntities())
            {
                int currentLevel = ctx.FaceAttributeHierarchies.Where(a => a.ClassAttribute_AttId == attId).FirstOrDefault().LevelNo;
                int newLevel = currentLevel - 1;

                try
                {
                    FaceAttributeHierarchy currentLevelAttr = ctx.FaceAttributeHierarchies.FirstOrDefault(a=>a.ClassAttribute_AttId == attId);
                    FaceAttributeHierarchy previouslyAboveAttr = ctx.FaceAttributeHierarchies.FirstOrDefault(a=> a.LevelNo == newLevel);
                    currentLevelAttr.LevelNo = newLevel;
                    previouslyAboveAttr.LevelNo = currentLevel;

                    ctx.SaveChanges();
                    return true;
                }
                catch { }
            }

            return false;
        }

        public bool MoveDownHierarchy(int attId) 
        {
            using (var ctx = new FaceRecEFEntities())
            {
                int currentLevel = ctx.FaceAttributeHierarchies.Where(a => a.ClassAttribute_AttId == attId).FirstOrDefault().LevelNo;
                int newLevel = currentLevel + 1;

                try
                {
                    FaceAttributeHierarchy currentLevelAttr = ctx.FaceAttributeHierarchies.FirstOrDefault(a => a.ClassAttribute_AttId == attId);
                    FaceAttributeHierarchy previouslyBelowAttr = ctx.FaceAttributeHierarchies.FirstOrDefault(a => a.LevelNo == newLevel);
                    currentLevelAttr.LevelNo = newLevel;
                    previouslyBelowAttr.LevelNo = currentLevel;

                    ctx.SaveChanges();
                    return true;
                }
                catch { }

            }
            return false;
        }
    }
}
