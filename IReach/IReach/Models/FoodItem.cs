using System;
using IReach.Models.Local;
using SQLite.Net.Attributes;

namespace IReach.Models
{
    public class FoodItem
    {
        public FoodItem()
        {
            var now = DateTime.UtcNow;
            MealType = MealTypeOption.All; 
            DateCreated = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);
            Target = 1000; 
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public MealTypeOption MealType { get; set; }
        public double Calories { get; set; }
        public double Target { get; set; }
        public int Servings { get; set; }
    }       
}
