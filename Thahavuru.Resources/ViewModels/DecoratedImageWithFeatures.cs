using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    [DataContract]
    public class DecoratedImageWithFeatures
    {
        [DataMember]
        public List<ImagePoint> facialFeatureSet;

        [DataMember]
        public Image DecoratedImage;
    }
}
