using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.ViewModels
{
    public class FaceUnresolved
    {
        public Rectangle[] REyeSet { get; set; }
        public Rectangle[] LEyeSet { get; set; }
        public Rectangle[] REarSet { get; set; }
        public Rectangle[] LEarSet { get; set; }
        public Rectangle[] MouthSet { get; set; }
        public Rectangle[] NoseSet { get; set; }

        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
    }
}
