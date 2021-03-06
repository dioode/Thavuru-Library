﻿using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thahavuru.Techniques.FaceRecT
{
    public class CascadeConfig
    {
        public CascadeConfig(int MaxWindowSize, int MinWindowSize, double ScaleIncreaseRate, int MinNeighbors, string ClassifierXML)
        {
            this.MaxWindowSize = MaxWindowSize;
            this.MinWindowSize = MinWindowSize;
            this.ScaleIncreaseRate = ScaleIncreaseRate;
            this.MinNeighbors = MinNeighbors;
            this.ClassifierXML = ClassifierXML;
        }

        public int MaxWindowSize { get; set; }
        public int MinWindowSize { get; set; }
        public double ScaleIncreaseRate { get; set; }
        public int MinNeighbors { get; set; }
        public string ClassifierXML { get; set; }



    }
}
