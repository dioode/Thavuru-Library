using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    [DataContract]
    public class UserInterfaceModel
    {
        public UserInterfaceModel()
        {
            SearchingPerson = new PersonVM();
        }
        [DataMember]
        public PersonVM SearchingPerson;

        [DataMember]
        public int PageNumber{ get; set; }

        private int maxLeaves;
        [DataMember]
        public int MaxLeaves { get {
                int x = 1;
                foreach (var item in SearchingPerson.FaceofP.FaceAttributes)
	            {
                    x *= item.NumberOfClasses; 
	            }
                return (int)x;
            }
        }

        [DataMember]
        public bool Next{ get; set; }

        [DataMember]
        public bool Back{ get; set; }
    }
}
