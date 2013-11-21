using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    [DataContract]
    public class FaceAttribute
    {
        [DataMember]
        public string ClassificationTechnique; //{ get; set; }
        
        [DataMember]
        public int AttributeId; //{ get; set; }

        [DataMember]
        public string Name; //{ get; set; }

        [DataMember]
        public bool IsBinary { get { return NumberOfClasses == 2 ? true: false;} }

        [DataMember]
        public bool IsBiometric;

        [DataMember]
        public int NumberOfClasses;

        [DataMember]
        public List<int> SortedClasses;

        [DataMember]
        public List<IndividualClass> ClassesInOrder;

        [OperationContract]
        public TrainingSet GetTrainingSet()
        {
            //This has to be populated with training faces using method in dataaccess layer.
            return new TrainingSet();
        }
    }
}
