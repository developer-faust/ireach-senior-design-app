using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Foods
{
    public class UserFoodItemViewModel : BaseViewModel
    {
        private FoodItem item;
        public UserFoodItemViewModel(FoodItem item, INavigation navigation = null) : base(navigation)
        {
            this.item = item; 
        }

        public string FoodName
        {
            get { return item.Name; }
        }

        public double _calories = 100; 
        public double Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                OnPropertyChanged("Calories");
                
            }
        }

        private int _servings = 1; 
        public int Servings
        {
            get
            {
                if (_servings == 0)
                {
                    return 1;
                }

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

        public DateTime DateCreated{ get; set; }

        public async void Save()
        {
            var foodEntry = new FoodItem();
            foodEntry.Name = FoodName;
            foodEntry.DateCreated = DateTime.UtcNow;
            foodEntry.Calories = Calories;
            foodEntry.Servings = Servings;

            await App.UserUserAsyncDataService.SaveFoodAsync(foodEntry); 
        }

        public async void Delete( )
        {
            await App.UserUserAsyncDataService.DeleteFoodAsync(item.ID); 

        }

        private double previousCalories;
        public void Recalculate()
        {
            previousCalories = Calories;
            Calories = previousCalories*Servings;
        }

    }
}
