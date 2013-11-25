﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Resources.ViewModels
{
    public class FaceAttributeHiearachy
    {
        public FaceAttributeHiearachy()
        {
            OrderedFaceAttributeSet = new List<FaceAttribute>();
        }
        public List<FaceAttribute> OrderedFaceAttributeSet { get; set; }
        public string FaceMatchingTechnique { get; set; }
    }
}
