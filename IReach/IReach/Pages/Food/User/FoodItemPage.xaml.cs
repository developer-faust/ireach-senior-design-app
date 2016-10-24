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
        private async void SaveClicked(object sender, EventArgs e)
        {
            ViewModel.Save();
            await Navigation.PopAsync(); 
        }

        private async void DeleteClicked(object sender, EventArgs e)
        {
            ViewModel.Delete();
            await Navigation.PopAsync();
        }

        private void SpeakClicked(object sender, EventArgs e)
        {
            
        }
    }

    public abstract class FoodItemPageXaml : ModelBoundContentPage<UserFoodItemViewModel>
    {
    }


}
