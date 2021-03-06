﻿using System.Diagnostics;
using IReach.Models;
using IReach.Pages.Base;
using IReach.ViewModels.Foods;
using Xamarin.Forms;

namespace IReach.Pages.Food.Usda
{
    public partial class BrowseFoodsPage : BrowseFoodsPageXaml
    {

        /// <summary>
        /// BrowseFoodsPage:
        /// 
        /// This is a xaml page that uses a ViewModel to bind all of its properties.
        /// The BrowseFoodsViewModel has all the properties and event trigers required to
        /// display this page. The view Model also contains the calls to the sqlite database.
        /// </summary>
   
        public BrowseFoodsPage ( )
        {
            InitializeComponent ( );
            BindingContext = new BrowseFoodsViewModel(this.Navigation);
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
           
            Debug.WriteLine("USDA Browse Foods Appearing");
            ViewModel.LoadItemsCommand.Execute (null ); 
        }   
    }

    public abstract class BrowseFoodsPageXaml : ModelBoundContentPage<BrowseFoodsViewModel>
    {
        
    }
}
