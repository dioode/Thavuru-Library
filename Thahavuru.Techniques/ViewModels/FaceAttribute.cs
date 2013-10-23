using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.ViewModels
{
    public class FaceAttribute
    {
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public bool IsBinary { get { return NumberOfClasses == 2 ? true: false;} }
        public int NumberOfClasses { get; set; }
        public List<int> SortedClasses { get; set; }
    }
}
