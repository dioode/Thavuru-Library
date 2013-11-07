using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    public class FaceAttribute
    {
        public string ClassificationTechnique; //{ get; set; }
        public int AttributeId; //{ get; set; }
        public string Name; //{ get; set; }
        public bool IsBinary { get { return NumberOfClasses == 2 ? true: false;} }
        public bool IsBiometric;
        public int NumberOfClasses { get; set; }
        public List<int> SortedClasses { get; set; }

        public TrainingSet GetTrainingSet()
        {
            //This has to be populated with training faces using method in dataaccess layer.
            return new TrainingSet();
        }
    }
}
