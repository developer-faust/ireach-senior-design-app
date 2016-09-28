using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using Xamarin.Forms;

namespace IReach.Views
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
            foodItem.CreationDate = DateTime.Now.ToString();
            await App.UserAsyncDb.SaveFoodAsync(foodItem);

            await this.Navigation.PopAsync(); 
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext;
            await App.UserAsyncDb.DeleteFoodAsync(foodItem.ID);
            await this.Navigation.PopAsync();
        }

        private void OnSpeakClicked(object sender, EventArgs e)
        {
            var foodItem = (FoodItem) BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(foodItem.Name);
        }
    }
}
