using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Person GetPersonByID(int personId)
        {
            //return dataAccess
            return new Person();
        }

        public Person GetPersonByNIC(string nicString)
        {
            //return dataAccess
            return new Person();
        }

        public List<Person> GetPersonByName(string name)
        {
            //return dataAccess
            return new List<Person>();
        }

        public List<Person> GetTraingSet(List<int> personIdSet)
        {
            //return dataAccess
            return new List<Person>();
        }
    }
}
