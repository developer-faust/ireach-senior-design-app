using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach.Models.Local
{
    public class WeeklyCaloriesDataPoint
    {
        public WeeklyCaloriesDataPoint()
        {
            Created = DateTime.MinValue; 

            Amount = 0;
        }
        
        public DateTime Created { get; set; } 
        public double Amount { get; set; }

        public string DateCreateString
        {
            get { return Created.ToString("M/dd"); }
        } 
    }


}
