using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.Classification
{
    public class BiometricAttributeFiller
    {

        internal void FillBiometricAttributes(Resources.ViewModels.PersonVM inputPerson, Resources.ViewModels.FaceAttribute faceAttribute)
        {
            switch (faceAttribute.Name.Trim())
            {
                case "EyesEbrows":
                    new EyesEyeBrowsRatioClassifier().Classify(ref inputPerson, null, faceAttribute);
                    break;
                case "EyesNose":
                    new EyesNoseRatioClassifier().Classify(ref inputPerson, null, faceAttribute);
                    break;
                case "EyesMouth":
                    new EyesMouthRatioClassifier().Classify(ref inputPerson, null, faceAttribute);
                    break;
                case "NoseMouth":
                    new NoseMouthRatioClassifier().Classify(ref inputPerson, null, faceAttribute);
                    break;
            } 
        }
    }
}
