using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.ViewModels
{
    public class GeometricFace : IFace
    {
        public Image faceImage { get; set; }
        public Rectangle REye { get; set; }
        public Rectangle LEye { get; set; }
        public Rectangle REar { get; set; }
        public Rectangle LEar { get; set; }
        public Rectangle Mouth { get; set; }
        public Rectangle Nose { get; set; }

    }
}
