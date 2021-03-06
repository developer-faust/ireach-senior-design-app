﻿using System.Diagnostics;
using IReach.Models;
using IReach.Pages.Base;
using IReach.ViewModels;
using IReach.ViewModels.Foods;
using IReach.Views;
using Xamarin.Forms;

namespace IReach.Pages.Food.Usda
{
    public partial class UsdaFoodGroupItemsPage : FoodGroupItemsPageXaml
    {
       
        public UsdaFoodGroupItemsPage (food_group group)
        {
            InitializeComponent ( );
            BindingContext = new FoodGroupItemsViewModel ( this.Navigation);

            ViewModel.GroupId = group.id;
            Debug.WriteLine("Display Foods in Group ID = {0}", group.id); 
        } 
     
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if ( ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy )
            //    return; 

            ViewModel.LoadItemsCommand.Execute ( null );
        }

        private void USDAFoodItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var foodItem = (food)e.SelectedItem;
            var foodPage = new UsdaFoodItemPage(foodItem); 

            Navigation.PushAsync(foodPage);

        }

        private void TextFilterChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("{0}", e.NewTextValue);
            ViewModel.SearchText = e.NewTextValue + " ";
            ViewModel.SearchCommand.Execute(null);
        }
    }

    public abstract class FoodGroupItemsPageXaml : ModelBoundContentPage<FoodGroupItemsViewModel>
    {
    }
}
