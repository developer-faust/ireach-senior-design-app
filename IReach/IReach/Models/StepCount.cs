using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models.Local;
using SQLite.Net.Attributes;

namespace IReach.Models
{
    public class StepCount
    {
        public StepCount()
        {
            var today = DateTime.UtcNow;
            date = DateTime.SpecifyKind(new DateTime(today.Year, today.Month, today.Day, 0, 0, 0), DateTimeKind.Utc);
            stepCount = 0;
        }

        public int ID { get; set; }
        public int stepCount { get; set; }
        public DateTime date { get; set; }
    }
}
