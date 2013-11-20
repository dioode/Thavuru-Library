using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    public class PersonVM
    {
        public IFace FaceofP; //{ get; set; }
        public string Name { get; set; }
        public int Id { get; set; }//Guid Id { get; set; }
        public string Address { get; set; }

        public Dictionary<int,List<int>> MatchedFaceIdSet { get; set; }
       
    }
}
