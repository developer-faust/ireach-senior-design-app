using System;
using IReach.Interfaces;
using IReach.Models;
using IReach.Pages.Base;
using IReach.Services;
using IReach.ViewModels.Foods;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class FoodItemPage : FoodItemPageXaml
    { 
        public FoodItemPage (FoodItem item)
        {
            InitializeComponent ( ); 
            BindingContext = new UserFoodItemViewModel(item);
        }
/*
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
        }*/


        private async void SaveClicked(object sender, EventArgs e)
        {
            ViewModel.Save();
            await Navigation.PopAsync();

        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            ViewModel.Delete();
            Navigation.PopAsync();
        }

        private void SpeakClicked(object sender, EventArgs e)
        {
            
        }
    }

    public abstract class FoodItemPageXaml : ModelBoundContentPage<UserFoodItemViewModel>
    {
    }


}
