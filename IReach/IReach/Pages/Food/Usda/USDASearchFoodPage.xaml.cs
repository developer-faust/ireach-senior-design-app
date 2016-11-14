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
        public UsdaSearchFoodPage(string searchText = null)
        {
            InitializeComponent();
            Debug.WriteLine("Usda Search for food: {0}", searchText);
            BindingContext = new UsdaSearchFoodViewModel(searchText);
        }

        private void TextFilterChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("{0}", e.NewTextValue);
            ViewModel.SearchText = e.NewTextValue + " ";
            ViewModel.SearchCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!string.IsNullOrEmpty(ViewModel.SearchText))
            {
                SearchEntry.Text = ViewModel.SearchText;
            }
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
