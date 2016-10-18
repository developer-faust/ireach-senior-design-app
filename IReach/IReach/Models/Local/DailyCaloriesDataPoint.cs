using System;

namespace IReach.Models.Local
{
    public class DailyCaloriesDataPoint
    {
        public DailyCaloriesDataPoint()
        {
            Day = DateTime.MinValue;
            FoodName = string.Empty;
            Servings = 0;
            Amount = 0;
            Target = 1500;
        }
        
        public string FoodName { get; set; }
        public DateTime Day { get; set; }
        public int Servings { get; set; }
        public double Amount { get; set; }
        public double Target { get; set; } 
        public string DayString
        {
            get { return Day.ToString("ddd"); }
        }
         
    }
}