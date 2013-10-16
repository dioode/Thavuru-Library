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
        public List<Image<Gray, byte>> trainingList { get; set; }
        public List<int> labelList { get; set; }
        public List<string> labelListS
        {
            get
            {
                var list = new List<string>(); 
                foreach (var item in labelList)
                {
                    list.Add(item.ToString());
                }
                return list;
            }
        }
        //public int GetTrainingSetCount{ get{return } set; }
    }
}
