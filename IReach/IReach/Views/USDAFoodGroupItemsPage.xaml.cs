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
    public partial class UsdaFoodGroupItemsPage : ContentPage
    {
        private FoodGroupItemsViewModel ViewModel
        {
            get { return BindingContext as FoodGroupItemsViewModel; }
        }
        public UsdaFoodGroupItemsPage (food_group group)
        {
            InitializeComponent ( );
            BindingContext = new FoodGroupItemsViewModel (  );

            ViewModel.GroupId = group.id;
            Debug.WriteLine("Display Foods in Group ID = {0}", group.id); 
        } 
     
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if ( ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy )
                return;

            ViewModel.LoadItemsCommand.Execute ( null );
        }

        private void USDAFoodItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*
            var selected = (food) e.SelectedItem;
            Debug.WriteLine("Selected Food: {0} ID = {1}", selected.short_desc, selected.id); 
            var usdaFood = App.NutritionDb.GetFoodWithID(selected.id);

            Debug.WriteLine("Retrieved Food short desc: {0}", usdaFood.short_desc);

            var usdaFoodPage = new USDAFoodItemPage();
            usdaFoodPage.BindingContext = usdaFood;

            Navigation.PushAsync(usdaFoodPage);*/
        }

        private void TextFilterChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("{0}", e.NewTextValue);
            ViewModel.SearchText = e.NewTextValue + " ";
            ViewModel.SearchCommand.Execute(null);
        }
    }
}
