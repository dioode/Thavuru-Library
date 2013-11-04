using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thahavuru.Resources.ViewModels;

namespace Thahavuru.Techniques.Classification
{
    public interface IBiometricClassifier
    {
        void Classify(ref PersonVM probeImage);
    }
}
