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
    public partial class USDABrowseFoodsPage : ContentPage
    {

        /// <summary>
        /// USDABrowseFoodsPage:
        /// 
        /// This is a xaml page that uses a ViewModel to bind all of its properties.
        /// The BrowseFoodsViewModel has all the properties and event trigers required to
        /// display this page. The view Model also contains the calls to the sqlite database.
        /// </summary>
        private BrowseFoodsViewModel ViewModel
        {
            get { return BindingContext as BrowseFoodsViewModel; }
        } 
         
        public USDABrowseFoodsPage ( )
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

       
    }
}
