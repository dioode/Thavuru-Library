using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;
using Thahavuru.Techniques.FaceRecT;

namespace Thahavuru.Techniques.Classification
{
    public class EyesMouthRatioClassifier : IClassifier
    {
        public void Classify(ref PersonVM probeImage, TrainingSet list, FaceAttribute currentAttrubute)
        {
            FeatureTracker ft = new FeatureTracker();
            var pointList = ft.GetFeaturePoints(probeImage.FaceofP.GetImage);
            double eyemouthratio = Math.Sqrt(Math.Pow(pointList.facialFeatureSet[0].X - pointList.facialFeatureSet[1].X, 2) + Math.Pow(pointList.facialFeatureSet[0].Y - pointList.facialFeatureSet[1].Y, 2)) 
                / (Math.Sqrt(Math.Pow(pointList.facialFeatureSet[3].X - pointList.facialFeatureSet[4].X, 2) + Math.Pow(pointList.facialFeatureSet[3].Y - pointList.facialFeatureSet[4].Y, 2)));

            BiometricClassifierCommon.CommonFiller(ref probeImage, eyemouthratio, currentAttrubute);
        }
    }
}
