using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Foods
{
    public class NutritionInfoViewModel : BaseViewModel
    {
        private static IUsdaFoodService FoodService { get; } = DependencyService.Get<IUsdaFoodService>();

        private int food_id;
        public NutritionInfoViewModel(int id, INavigation navigation = null) : base(navigation)
        {
            food_id = id;
            GetNutritions();
        }

        public async void GetNutritions()
        {
            FoodNutritionsInfo = await FoodService.GetFoodNutritions(food_id);
            Debug.WriteLine($"Found Nutritions for {food_id} Count : {FoodNutritionsInfo.Count}");
        }
        public int FoodID
        {
            get { return food_id; }
            set
            {
                food_id = value;
                OnPropertyChanged("FoodID");
            }
        }
        private ObservableCollection<FoodNutrients> _foodNutrients;
        public ObservableCollection<FoodNutrients> FoodNutritionsInfo
        {
            get { return _foodNutrients; }
            set
            {
                _foodNutrients = value;
                OnPropertyChanged("FoodNutritionsInfo");
            }
        }
    }
}
