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
            //return dataAccess
            return new TrainingSet();
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
                    PersonM.Address = (string)person.Address;
                }
            }

            return PersonM;
        }

        public PersonVM GetPersonByNIC(string nicString)
        {
            //return dataAccess
            return new PersonVM();
        }

        public List<PersonVM> GetPersonByName(string name)
        {
            //return dataAccess
            return new List<PersonVM>();
        }

        public TrainingSet GetTraingSet(List<int> personIdSet)
        {
            //return dataAccess
            return new TrainingSet();
        }
    }
}
