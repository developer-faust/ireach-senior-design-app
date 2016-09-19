﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace IReach.ViewModels
{
    public class UsdaFoodItemViewModel : BaseViewModel
    {
       
        private static IUsdaFoodService FoodService { get; } = DependencyService.Get<IUsdaFoodService>();
        private food item;
        public UsdaFoodItemViewModel(food item)
        {
            this.item = item;
        }

        public string FoodName
        {
            get { return item.short_desc; }
        }

        private int _calories;
        public int Calories
        {
            get { return 100; }
            set { SetProperty(ref _calories, value); }
        }

        private int _servings;
        public int Servings
        {
            get
            {
                if (_servings > 1)
                    return 2;
                return _servings;
            }
            set { SetProperty(ref _servings, value); }
        }


        public async void Save()
        {
            var foodEntry = new FoodItem();
            foodEntry.Name = FoodName;
            foodEntry.Calories = Calories;
            foodEntry.Servings = Servings;
             
            App.Database.SaveItem(foodEntry); 

        }
    }
}
