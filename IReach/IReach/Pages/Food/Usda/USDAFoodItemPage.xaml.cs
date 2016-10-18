using System;
using IReach.Models;
using IReach.Pages.Base;
using IReach.ViewModels;
using IReach.ViewModels.Usda;
using Xamarin.Forms;

namespace IReach.Pages.Food.Usda
{
    public partial class UsdaFoodItemPage : UsdaFoodItemPageXaml
    { 
     
        public UsdaFoodItemPage (food  item)
        {
            InitializeComponent ( );
            BindingContext = new UsdaFoodItemViewModel(item);  
        } 

        async void SaveClicked(object sender, EventArgs e)
        {
            // Call the base viewModel object.
            ViewModel.Save(); 
            await this.Navigation.PopToRootAsync();
        }
         
    }

    public abstract class UsdaFoodItemPageXaml : ModelBoundContentPage<UsdaFoodItemViewModel>
    {
    }
}
