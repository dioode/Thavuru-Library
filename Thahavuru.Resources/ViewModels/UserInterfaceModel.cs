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
        [DataMember]
        public PersonVM SearchingPerson;

        [DataMember]
        public int PageNumber{ get; set; }

        [DataMember]
        public int MaxLeaves { get; set; }

        [DataMember]
        public bool Next{ get; set; }

        [DataMember]
        public bool Back{ get; set; }
    }
}
