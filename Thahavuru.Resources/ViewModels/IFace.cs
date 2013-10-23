using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    public interface IFace
    {
        public Image FaceImage { get; set; }
        public List<FaceAttribute> FaceAttributes { get; set; }
    }
}
