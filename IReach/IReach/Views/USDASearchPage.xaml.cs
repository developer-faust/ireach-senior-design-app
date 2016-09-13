using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Data;
using IReach.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IReach.ViewModels;

namespace IReach.Views
{
    public partial class USDASearchPage : ContentPage
    {
        
        public USDASearchPage ( )
        {
            InitializeComponent ( );
            BindingContext = new BrowseFoodsViewModel(this); 
        }

     
        /*

        private void SearchButtonClicked(object sender, EventArgs e)
        {
            var usdaFood = new USDAFoodGroupItemsPage( SearchFoodGroupID ); 
            Navigation.PushAsync(usdaFood);
        } 
        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            foodGroupListView.ItemsSource = App.NutritionDb.GetFoodGroups(); 
        }

        private void OnGroupSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (food_group)e.SelectedItem;
            SearchFoodGroupID = item.id;
            FoodGroupName = item.name;

            Debug.WriteLine("Food Group Selected: {0} id: {1}", FoodGroupName, SearchFoodGroupID );

            var usdaFood = new USDAFoodGroupItemsPage ( SearchFoodGroupID );
            Navigation.PushAsync ( usdaFood );
        }
        */
    }
}
