using System.Diagnostics;
using IReach.Models;
using IReach.Pages.Base;
using IReach.ViewModels;
using IReach.ViewModels.Usda;
using Xamarin.Forms;

namespace IReach.Pages.Food.Usda
{
    public partial class UsdaSearchFoodPage : SearchFoodPageXaml
    {
        
        public UsdaSearchFoodPage ( )
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
            var foodPage = new Pages.Food.Usda.UsdaFoodItemPage(foodItem);  
            Navigation.PushAsync(foodPage);
        }
    }

    public abstract class SearchFoodPageXaml : ModelBoundContentPage<UsdaSearchFoodViewModel>
    {
    }
}
