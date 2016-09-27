using System;
using SQLite.Net.Attributes;

namespace IReach.Models
{
    public class FoodItem
    {
        public FoodItem()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public double Calories { get; set; }
        public int Servings { get; set; }
    }
}
