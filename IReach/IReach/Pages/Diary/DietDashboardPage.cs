using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Localization;
using IReach.ViewModels.Diary;
using IReach.Views.Diet;
using Xamarin.Forms;

namespace IReach.Pages.Diary
{
    public class DietDashboardPage : ContentPage
    {
        private StackLayout contentFrame;
        private DietDashboardChartViewModel DietChartViewModel { get; set; }
  
        public DietDashboardPage()
        {
            this.SetBinding(Page.TitleProperty, new Binding() {Source = TextResources.DiaryDashboardPage_Title});

            var dietChartView = new DietDashboardChartView()
            {
                BindingContext = DietChartViewModel = new DietDashboardChartViewModel(Navigation)
            };  

            Content = dietChartView;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Content.IsVisible = true;
             
            await DietChartViewModel.ExecuteLoadSeedDataCommand(); 
             
        }
    }
}
