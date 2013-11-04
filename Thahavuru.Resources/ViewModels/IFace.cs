using Emgu.CV;
using Emgu.CV.Structure;
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
        Image<Gray, byte> FaceImage { get; set; }
        List<FaceAttribute> FaceAttributes { get; set; }
        Image GetImage{get;}
    }
}
