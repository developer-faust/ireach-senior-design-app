using System;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Localization;
using IReach.Models;
using IReach.Statics;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Foods
{
    public class FoodDetailViewModel : BaseViewModel
    {
        private readonly IFoodDataService _DataClient;
        public FoodItem Food { get; set; }
        public FoodDetailViewModel(INavigation navigation, FoodItem food = null)
        {
            if (navigation == null)
            {
                throw new ArgumentNullException("navigation", "An instance of INavigation must be passed to the FoodDetailViewModel constructor");
            }

            Navigation = navigation;
            if (food == null)
            {
                Food = new FoodItem();
                this.Title = TextResources.Foods_NewFood;
            }
            else
            {
                Food = food;
                this.Title = food.Name.Replace(',', ' ').Substring(0, 20);
            }

            _DataClient = DependencyService.Get<IFoodDataService>();  
        }

        Command saveFoodCommand;

        public Command SaveFoodCommand
        {
            get { return saveFoodCommand ?? (saveFoodCommand ?? new  Command(async () => await ExecuteSaveFoodCommand())); }
        }

        async Task ExecuteSaveFoodCommand()
        { 
            if(IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(Food.Name))
            {
                MessagingCenter.Send(Food, MessagingServiceConstants.SAVE_FOOD_ERROR);
            }

            IsBusy = true;

            await _DataClient.SaveFoodAsync(Food);
            MessagingCenter.Send(Food, MessagingServiceConstants.SAVE_FOOD);

            IsBusy = false;
        }
    }
}
