using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.ViewModels;
using Xamarin.Forms;

namespace IReach.Views
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
            var foodPage = new USDAFoodItemPage(foodItem);
            foodPage.BindingContext = foodItem; 
          
            Navigation.PushAsync(foodPage);
        }
    }
}
