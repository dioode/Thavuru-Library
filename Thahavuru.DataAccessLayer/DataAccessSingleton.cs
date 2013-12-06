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
        private static DataAccessSingleton instance = new DataAccessSingleton();
        private DataAccessSingleton() { }

        public static DataAccessSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Get training set set for classification attribute
        /// </summary>
        /// <param name="classAttributeId"></param>
        /// <returns></returns>
        public TrainingSet GetTraingSet(int classAttributeId)
        {
            TrainingSet TSet = new TrainingSet();
            TSet.trainingList = new List<Image<Gray, byte>>();
            TSet.labelList = new List<int>();

            using (var ctx = new FaceRecEFEntities())
            {
                var TrainSet =
                    (from c in ctx.IndClasses
                     join i in ctx.ClassElementImages
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

        /// <summary>
        /// Get person information (Name, Address etc.)
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
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
                    PersonM.Address = (string)person.Address;
                }
            }

            return PersonM;
        }


        /// <summary>
        /// Get person information using NIC number
        /// </summary>
        /// <param name="nicString"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get person by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
                    foreach (var p in persons)
                    {
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


        /// <summary>
        /// Get classification attribute hierarchy for decision tree
        /// </summary>
        /// <returns></returns>
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
                    fa.IsBiometric = (bool)(fah.IsBiometric == null ? false : fah.IsBiometric);
                    fa.NumberOfClasses = (int)(fah.NoOfClasses == null ? 0 : fah.NoOfClasses);
                    fa.Name = fah.Name;

                    var indClasses = (from i in ctx.IndClasses
                                      where i.Class_Attrubute_Id == fa.AttributeId
                                      select new { name = i.Name, classNumber = i.ClassNumber, minValue = i.ValueRangeLowerBound, maxValue = i.ValueRangeUpperBound }).ToList();
                    if (indClasses != null)
                    {
                        foreach (var indClass in indClasses)
                        {
                            fa.ClassesInOrder.Add(new IndividualClass() { ClassNumber = (int)indClass.classNumber, Name = indClass.name, MinValue = Convert.ToDouble(indClass.minValue), MaxValue = Convert.ToDouble(indClass.maxValue) });
                        }
                    }

                    faceAttributeHiearachy.OrderedFaceAttributeSet.Add(fa);
                }
                faceAttributeHiearachy.FaceMatchingTechnique = technique.ToString();
            }

            return faceAttributeHiearachy;
        }

        /// <summary>
        /// Reduce face search space for classes matched for all attiributes in the hierarchy 
        /// </summary>
        /// <param name="searchingPerson"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public TrainingSet GetAllNarrowdownFaceImageSet(PersonVM searchingPerson, int pageNumber)
        {
            var wantedSearchingTrack = searchingPerson.SearchTrakKeeper[pageNumber - 1];

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

                    faceImageSet = faceImageSet.Where(x => personIdSetForCurrentAttrubute.Select(t => t.personId).Contains((int)x.Person_Id)).ToList();
                }

                var trainingSet = new TrainingSet();
                string imgUri = ctx.SystemConfigVariables.Where(x => x.VariableName.Trim() == "VAR_PATH").First().VariableValue;

                foreach (var item in faceImageSet)
                {
                    trainingSet.trainingImageURIList.Add(item.Image_uri);
                    trainingSet.trainingList.Add(new Image<Gray, byte>(@imgUri + item.Image_uri));
                    trainingSet.labelList.Add((int)item.Person_Id);
                }

                return trainingSet;


            }

        }

    }
}
