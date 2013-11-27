using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.FaceRecT;

namespace Thahavuru.Techniques.Classification
{
    public class EyesNoseRatioClassifier : IBiometricClassifier
    {
        // method to calculate the eyes inner width to nose height ratio
        public void Classify(ref PersonVM probeImage)
        {
            FeatureTracker ft = new FeatureTracker();
            var pointList = ft.GetFeaturePoints(probeImage.FaceofP.GetImage);
            double eyesnoseratio = Math.Sqrt(Math.Pow(pointList.facialFeatureSet[24].X - pointList.facialFeatureSet[25].X, 2) + Math.Pow(pointList.facialFeatureSet[24].Y - pointList.facialFeatureSet[25].Y, 2))
                / (Math.Sqrt(Math.Pow(pointList.facialFeatureSet[22].X - pointList.facialFeatureSet[49].X, 2) + Math.Pow(pointList.facialFeatureSet[22].Y - pointList.facialFeatureSet[49].Y, 2)));


        }
    }
}
