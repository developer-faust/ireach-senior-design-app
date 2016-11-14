using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using IReach.Interfaces;
using IReach.Models;
using IReach.Services;
using Xamarin.Forms;
using IReach.ViewModels.Base;

namespace IReach.ViewModels.Usda
{
    public class UsdaFoodItemViewModel : BaseViewModel
    {

        private static IUsdaFoodService FoodService { get; } = DependencyService.Get<IUsdaFoodService>();
        private food item;
        private double _caloriesFromDB;
        public UsdaFoodItemViewModel(food item, INavigation navigation = null) : base(navigation)
        {
            this.item = item;
            GetCalories();
        }

        public string FoodName
        {
            get { return UseRegex(item.short_desc); }
        }
        public static string UseRegex(string strIn)
        {
            // Replace invalid characters with empty strings.
            var result = Regex.Replace(strIn, @"[^\w\.@-]", " ");
            if (result.Length > 20)
            {
                result = result.Substring(0, 20);
            }

            return result;
        }

        private double _calories;
        public double Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                OnPropertyChanged("Calories");
            }
        }

        public async void GetCalories()
        {
            var cal = await App.NutritionDataService.GetNutrition(item.id);
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
                    _servings = value;
                    OnPropertyChanged("Servings");
                    Recalculate();
                }
            }
        }


        public async void Save()
        {
            var foodEntry = new FoodItem();

            var now = DateTime.UtcNow;

            // TODO: Change Hard Coded Sample Today's Date from 6 * 7 (six weeks * 7 DaysPer Week) to its Default 
            // The data is calculated backwords it will get 6 weeks worth of data upto current week.
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);

            foodEntry.Name = FoodName;
            foodEntry.DateCreated = today;
            foodEntry.Calories = Calories;
            foodEntry.UsdaFoodId = item.id;

            if (Servings == 0)
            {
                Servings = 1;
            }
            foodEntry.Servings = Servings;

            App.Database.SaveItem(foodEntry);
        }

        public void Recalculate()
        {
            Calories = _caloriesFromDB * Servings;
        }
    }
}
