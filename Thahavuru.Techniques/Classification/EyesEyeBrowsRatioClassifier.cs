using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.FaceRecT;

namespace Thahavuru.Techniques.Classification
{
    public class EyesEyeBrowsRatioClassifier :IBiometricClassifier
    {
        //method to calculate the eyes outer width to eye brows outer width ratio 
        public void Classify(ref PersonVM probeImage)
        {
            FeatureTracker ft = new FeatureTracker();
            var pointList = ft.GetFeaturePoints(probeImage.FaceofP.GetImage);
            double eyeseyebrowsratio = Math.Sqrt(Math.Pow(pointList.facialFeatureSet[23].X - pointList.facialFeatureSet[26].X, 2) + Math.Pow(pointList.facialFeatureSet[23].Y - pointList.facialFeatureSet[26].Y, 2))
                / (Math.Sqrt(Math.Pow(pointList.facialFeatureSet[12].X - pointList.facialFeatureSet[15].X, 2) + Math.Pow(pointList.facialFeatureSet[12].Y - pointList.facialFeatureSet[15].Y, 2)));


        }
    }
}
