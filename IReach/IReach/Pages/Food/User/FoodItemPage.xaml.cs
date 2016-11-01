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
            BindingContext = new UserFoodItemViewModel(item, this.Navigation);  
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
          
        private async void NutritionInfoClicked(object sender, EventArgs e)
        {

            var nutritionInfoPage = new FoodDetailPage()
            {
                BindingContext = new FoodDetailViewModel(this.Navigation),
                Title = "Food Nutrition Info"
            };

            await Navigation.PushAsync(nutritionInfoPage);
        }
    }

    public abstract class FoodItemPageXaml : ModelBoundContentPage<UserFoodItemViewModel>
    {
    }


}
