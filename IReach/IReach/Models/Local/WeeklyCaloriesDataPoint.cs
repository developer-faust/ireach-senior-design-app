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
            Date = DateTime.MinValue;  
            Amount = 0;
        }
        
        public DateTime Date { get; set; } 
        public double Amount { get; set; }

        public string DateString
        {
            get { return Date.ToString("ddd dd-mmm"); }
        } 

    }
}
