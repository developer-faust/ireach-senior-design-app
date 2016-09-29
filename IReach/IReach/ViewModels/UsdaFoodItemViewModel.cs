using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using MvvmHelpers;
using Xamarin.Forms;
using IReach; 

namespace IReach.ViewModels
{
    public class UsdaFoodItemViewModel : BaseViewModel
    {
       
        private static IUsdaFoodService FoodService { get; } = DependencyService.Get<IUsdaFoodService>();
        private food item;
        private double _caloriesFromDB;
        public UsdaFoodItemViewModel(food item)
        {
            this.item = item;
            GetCalories();
        }

        public string FoodName
        {
            get { return item.short_desc; }
        }

        private double _calories;
        public double Calories { get { return _calories; } set { SetProperty(ref _calories, value); } }

        public async void GetCalories()
        { 
            var cal = await App.NutritionDb.GetNutrition(item.id);
            _caloriesFromDB = cal.amount;
            Debug.WriteLine("Calories From DB = {0}", (_caloriesFromDB / 1000));
            Calories = _caloriesFromDB;
        }


        private int _servings;
        public int Servings
        {
            get
            {
                return _servings;
            }
            set
            {
                if (_servings != value)
                {
                    SetProperty(ref _servings, value);
                    Recalculate();
                } 
            }
        } 
         

        public async void Save()
        {
            var foodEntry = new FoodItem();
            foodEntry.Name = FoodName;
            foodEntry.DateCreated = DateTime.UtcNow;
            foodEntry.Calories = Calories;
            foodEntry.Servings = Servings;
             
            App.Database.SaveItem(foodEntry); 
        }

        public void Recalculate()
        {  
            Calories = _caloriesFromDB * Servings;
        }
    }
}
