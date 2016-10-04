using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach.Models.Local
{
    public class DailyStepsDataPoint
    {
        public DailyStepsDataPoint()
        {
            
        } 

        public double Amount { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public DateTime StartDate { get; internal set; }
    }
}
