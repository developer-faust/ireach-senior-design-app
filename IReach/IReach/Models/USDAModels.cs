﻿using SQLite.Net.Attributes;
namespace IReach.Models
{
    public class common_nutrient
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
    }
     
    public class food
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; } 
        public int food_group_id { get; set; } 
        public string long_desc { get; set; }
        public string short_desc { get; set; }
        public string common_names { get; set; }
        public string manufac_name { get; set; }
        public string sci_name { get; set; }
        public double nitrogen_factor { get; set; }
        public double protein_factor { get; set; }
        public double fat_factor { get; set; }
        public double calorie_factor { get; set; }  
    }
     
    public class food_group
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
    }
     
    public class nutrient
    {
        [PrimaryKey, AutoIncrement] 
        public int id { get; set; }
        public string units { get; set; }
        public string tagname { get; set; }
        public string name { get; set; }
        public int num_decimal_places { get; set; }
        public int sr_order { get; set; }
    }
     
    public class nutrition
    {
        [PrimaryKey, AutoIncrement]
        public int food_id { get; set; }
        
        public int nutrient_id { get; set; }
        public double amount { get; set; } 
    }


    public class FoodNutrients
    {
        public string name { get; set; }
        public double amount { get; set; }
        public string units { get; set; }

    }


}
