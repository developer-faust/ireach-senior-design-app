using System;
using System.Diagnostics;
using IReach.Interfaces;
using IReach.Models;
using IReach.Pages.Base;
using IReach.Pages.Food.Usda;
using IReach.Services;
using IReach.ViewModels.Foods;
using IReach.ViewModels.Usda;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class FoodItemPage : FoodItemPageXaml
    {
        private FoodItem m_foodItem;

        public FoodItemPage(FoodItem item)
        {
            InitializeComponent();
            m_foodItem = item;
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

        private void NutritionInfoClicked(object sender, EventArgs e)
        {
            var foodDetail = new FoodDetailPage(m_foodItem.UsdaFoodId);
            Navigation.PushAsync(foodDetail);
        }

        private void FindCalorieInfoClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Searching Calorie info For Food : {0}", m_foodItem.Name);
            var searchFood = new UsdaSearchFoodPage(m_foodItem.Name);

            Navigation.PushAsync(searchFood);
        }

    }

    public abstract class FoodItemPageXaml : ModelBoundContentPage<UserFoodItemViewModel>
    {
    }
}
