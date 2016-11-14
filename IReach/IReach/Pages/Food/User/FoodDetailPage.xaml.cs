using System;
using System.Diagnostics;
using IReach.Pages.Base;
using IReach.ViewModels.Foods;
using IReach.Views.Diet;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class FoodDetailPage : FoodDetailPageXaml
    {
        private StackLayout contentFrame;
        private FoodNutritionChartViewModel NutritionChartViewModel { get; set; }
        public FoodDetailPage(int foodId)
        {
            InitializeComponent();
            BindingContext = new NutritionInfoViewModel(foodId, this.Navigation);
            Debug.WriteLine("Food ID = {0}", foodId);
        }
    }

    public abstract class FoodDetailPageXaml : ModelBoundContentPage<NutritionInfoViewModel>
    {
    }
}
