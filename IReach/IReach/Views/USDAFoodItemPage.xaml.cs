using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.ViewModels;
using Xamarin.Forms;

namespace IReach.Views
{
    public partial class USDAFoodItemPage : ContentPage
    {

        private UsdaFoodItemViewModel ViewModel
        {
            get { return BindingContext as UsdaFoodItemViewModel; }
        }
        private food _foodItem;
        public USDAFoodItemPage (food  item)
        {
            InitializeComponent ( );
            BindingContext = new UsdaFoodItemViewModel(item);

            _foodItem = item;
        }




    }
}
