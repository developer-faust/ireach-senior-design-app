using System;
using System.Collections.Generic;
using System.ComponentModel;
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
