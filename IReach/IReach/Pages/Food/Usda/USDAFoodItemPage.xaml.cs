using System;
using IReach.Models;
using IReach.ViewModels;
using IReach.ViewModels.Usda;
using Xamarin.Forms;

namespace IReach.Pages.Food.Usda
{
    public partial class USDAFoodItemPage : ContentPage
    {

        private UsdaFoodItemViewModel ViewModel
        {
            get { return BindingContext as UsdaFoodItemViewModel; }
        }
     
        public USDAFoodItemPage (food  item)
        {
            InitializeComponent ( );
            BindingContext = new UsdaFoodItemViewModel(item);  
        } 

        async void SaveClicked(object sender, EventArgs e)
        {
            ViewModel.Save();
            await this.Navigation.PopToRootAsync();
        }
         
    }
}
