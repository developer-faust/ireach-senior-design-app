using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach.Models
{
    public class DietChartModel
    {
        public string Name { get; set; } 
        public double Value { get; set; }
        public double Size { get; set; }


        public DietChartModel(string name, double value)
        {
            Name = name;
            Value = value;
            Size = 1800;
        }

        public double Deficit
        {
            get { return Size - Value; }
        }
    }
}
