using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.ViewModels
{
    public class TrainingSet
    {
        List<Image<Gray, byte>> trainingList { get; set; }
        List<int> labelList { get; set; }
    }
}
