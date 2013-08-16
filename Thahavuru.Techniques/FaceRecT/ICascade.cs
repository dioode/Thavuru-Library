using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.FaceRecT
{
    public interface ICascade
    {
        Rectangle[] FaceDetection(Bitmap probe, CascadeConfig config);
    }
}
