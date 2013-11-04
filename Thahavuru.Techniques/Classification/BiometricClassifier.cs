using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.FaceRecT;

namespace Thahavuru.Techniques.Classification
{
    public class BiometricClassifier : IBiometricClassifier
    {
           
        void Classify(ref PersonVM probeImage)
        {
            FeatureTracker ft = new FeatureTracker(probeImage.FaceofP.GetImage);
            var pointList = ft.GetFeaturePoints();

        }
    }
}
