using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    public class FaceUnresolved
    {
        public List<Rectangle> REyeSet { get; set; }
        public List<Rectangle> LEyeSet { get; set; }
        public List<Rectangle> REarSet { get; set; }
        public List<Rectangle> LEarSet { get; set; }
        public List<Rectangle> MouthSet { get; set; }
        public List<Rectangle> NoseSet { get; set; }

        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
    }
}
