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
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MaxValue;

            Amount = 0;
        }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double Amount { get; set; }

        public string StartDateString
        {
            get { return StartDate.ToString("M/dd"); }
        }
        public string EndDateString
        {
            get { return EndDate.ToString("M/dd"); }
        }

    }
}
