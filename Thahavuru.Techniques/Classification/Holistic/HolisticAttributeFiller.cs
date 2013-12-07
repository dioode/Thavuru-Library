using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public class HolisticAttributeFiller
    {
        internal void Classify(ref PersonVM inputPerson, TrainingSet trainigSet, FaceAttribute faceAttribute)
        {
            switch (faceAttribute.ClassificationTechnique.Trim())
            {
                case "PCA":
                    new PCAClassifier().Classify(ref inputPerson, trainigSet, faceAttribute);
                    break;
                case "LDA":
                    new LDAClassifier().Classify(ref inputPerson, trainigSet, faceAttribute);
                    break;
                case "SVM":
                    new SVMClassifier().Classify(ref inputPerson, trainigSet, faceAttribute);
                    break;
            }
        }
    }
}
