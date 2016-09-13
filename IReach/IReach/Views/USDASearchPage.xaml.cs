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
        private BrowseFoodsViewModel ViewModel
        {
            get { return BindingContext as BrowseFoodsViewModel; }
        } 
         
        public USDASearchPage ( )
        {
            InitializeComponent ( );
            BindingContext = new BrowseFoodsViewModel(  );
            ListviewFoodGrp.ItemTapped += (sender, args) =>
            {
                if (ListviewFoodGrp.SelectedItem == null)
                {
                    return;
                }

                var group = ListviewFoodGrp.SelectedItem as food_group;
                if ( group != null)
                {
                    Debug.WriteLine("Selected: Name = {0} Id = {1}", group.name, group.id);
                    this.Navigation.PushAsync(new UsdaFoodGroupItemsPage(group));
                    ListviewFoodGrp.SelectedItem = null;
                }
            };
        }

        protected override void OnAppearing ( )
        {
            base.OnAppearing ( );
            if ( ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy )
                return;

            ViewModel.LoadItemsCommand.Execute ( null );

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
