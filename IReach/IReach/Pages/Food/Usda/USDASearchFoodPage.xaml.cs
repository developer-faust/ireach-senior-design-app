using System.Diagnostics;
using IReach.Models;
using IReach.ViewModels;
using IReach.ViewModels.Usda;
using Xamarin.Forms;

namespace IReach.Pages.Food.Usda
{
    public partial class USDASearchFoodPage : ContentPage
    {
        private UsdaSearchFoodViewModel ViewModel
        {
            get { return BindingContext as UsdaSearchFoodViewModel; }
        }

        public USDASearchFoodPage ( )
        {
            InitializeComponent ( );
            BindingContext = new UsdaSearchFoodViewModel ( );
        } 
        private void TextFilterChanged(object sender, TextChangedEventArgs e)
        { 
            Debug.WriteLine ( "{0}", e.NewTextValue );
            ViewModel.SearchText = e.NewTextValue + " ";
            ViewModel.SearchCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.SearchText = string.Empty;
        }

        private void FoodItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var foodItem = (food)e.SelectedItem;
            var foodPage = new Pages.Food.Usda.USDAFoodItemPage(foodItem);
            foodPage.BindingContext = foodItem; 
          
            Navigation.PushAsync(foodPage);
        }
    }
}
