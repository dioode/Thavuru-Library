using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Thahavuru.Resources.ViewModels
{
    public interface IFace
    {
        [DataMember]
        Image<Gray, byte> FaceImage { get; set; }
        
        [DataMember]
        List<FaceAttribute> FaceAttributes { get; set; }
        
        [DataMember]
        Image GetImage{get;}
    }
}
