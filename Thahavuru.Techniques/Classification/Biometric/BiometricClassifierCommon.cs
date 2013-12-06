using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public class BiometricClassifierCommon
    {
        public static void CommonFiller(ref PersonVM person, double ratioValue, FaceAttribute currentAttrubute)
        {
            var attribute = new FaceAttribute();
            attribute.AttributeId = currentAttrubute.AttributeId;
            attribute.ClassificationTechnique = currentAttrubute.ClassificationTechnique;
            attribute.IsBiometric = currentAttrubute.IsBiometric;
            attribute.Name = currentAttrubute.Name;
            attribute.NumberOfClasses = currentAttrubute.NumberOfClasses;
                        
            foreach (var item in currentAttrubute.ClassesInOrder)
	        {
                if (item.MinValue < ratioValue && item.MaxValue >= ratioValue)
	            {
		            attribute.SortedClasses.Add(1);
                    attribute.ClassesInOrder.Add(currentAttrubute.ClassesInOrder.Where(x => x.ClassNumber == Convert.ToInt32(1)).First());
                    attribute.SortedClasses.Add(2);
                    attribute.ClassesInOrder.Add(currentAttrubute.ClassesInOrder.Where(x => x.ClassNumber == Convert.ToInt32(2)).First());
                    break;
	            }
                else
                {
                    attribute.SortedClasses.Add(2);
                    attribute.ClassesInOrder.Add(currentAttrubute.ClassesInOrder.Where(x => x.ClassNumber == Convert.ToInt32(2)).First());
                    attribute.SortedClasses.Add(1);
                    attribute.ClassesInOrder.Add(currentAttrubute.ClassesInOrder.Where(x => x.ClassNumber == Convert.ToInt32(1)).First());
                    break;
                }
                
	        }

            person.FaceofP.FaceAttributes.Add(attribute);

        }
    }
}
