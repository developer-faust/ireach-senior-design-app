using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace IReach.ViewModels
{
    public class UsdaFoodItemViewModel : BaseViewModel
    {
       
        private static IUsdaFoodService FoodService { get; } = DependencyService.Get<IUsdaFoodService>();
        private food item;
        public UsdaFoodItemViewModel(food item)
        {
            this.item = item;
        }

        public string FoodName
        {
            get { return item.short_desc; }
        }

        


    }
}
