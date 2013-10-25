using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.DataAccessLayer;


namespace Thahavuru.Techniques.WebServiceMethods
{
    public class FaceMatchAdapter : IFaceMatchAdapter
    {
        
        public Person FillAttributeValues(Person inputPerson, FaceAttributeHiearachy providedHiearachy) 
        {
            foreach (var faceAttribute in providedHiearachy.OrderedFaceAttributeSet)
            {
                faceAttribute.GetTrainingSet();
            }
        }
    }
}
