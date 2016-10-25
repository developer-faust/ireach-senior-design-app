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
        private FoodItem foodItem;
        public UserFoodItemViewModel(FoodItem item, INavigation navigation = null) : base(navigation)
        {
            this.Navigation = navigation;
            
            foodItem = item; 
        }
         
        
        public string FoodName
        {
            get { return foodItem.Name; }
            set
            {
                foodItem.Name = value;
                OnPropertyChanged("FoodName");
            }
        }

        private double _calories; 
        public double Calories
        {
            get
            {
                return foodItem.Calories;
            }
            set
            { 
                foodItem.Calories = value;
                OnPropertyChanged("Calories"); 
            }
        }
         
        public int Servings
        {
            get
            {
                return foodItem.Servings;
            }
            set
            {
                foodItem.Servings = value;
                OnPropertyChanged("Servings");
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return foodItem.DateCreated;
            }
            set
            {
                foodItem.DateCreated = value;
                OnPropertyChanged("DateCreated");
            }
        }

        public async void GetCalories()
        {

        }

        public async void Save()
        {
            var now = DateTime.UtcNow;

            // TODO: Change Hard Coded Sample Today's Date from 6 * 7 (six weeks * 7 DaysPer Week) to its Default 
            // The data is calculated backwords it will get 6 weeks worth of data upto current week.
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);
            foodItem.DateCreated = today;

            await App.UserUserAsyncDataService.SaveFoodAsync(foodItem); 
        }

        public async void Delete( )
        {
            await App.UserUserAsyncDataService.DeleteFoodAsync(foodItem.ID);
        }
    }
}
