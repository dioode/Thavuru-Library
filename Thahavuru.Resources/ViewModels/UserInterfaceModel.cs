using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    public class UserInterfaceModel
    {
        public PersonVM SearchingPerson;

        public int PageNumber{ get; set; }

        public bool Next{ get; set; }

        public bool Back{ get; set; }
    }
}
