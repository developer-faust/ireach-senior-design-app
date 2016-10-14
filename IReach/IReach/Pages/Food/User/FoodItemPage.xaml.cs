using System;
using IReach.Interfaces;
using IReach.Models;
using IReach.Services;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class FoodItemPage : ContentPage
    {
        public FoodItemPage ( )
        {
            InitializeComponent ( );
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext; 
            var now = DateTime.UtcNow;
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);

            foodItem.DateCreated = today;
            await App.UserUserAsyncDataService.SaveFoodAsync(foodItem);
            await this.Navigation.PopAsync(); 
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext;
            await App.UserUserAsyncDataService.DeleteFoodAsync(foodItem.ID);
            await this.Navigation.PopAsync();
        }

        private void OnSpeakClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(foodItem.Name);
        }
    }
}
