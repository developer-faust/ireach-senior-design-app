using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Localization;
using IReach.Statics;
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

            // Messaging for android devices
            Device.OnPlatform(
                Android: () => MessagingCenter.Subscribe<DietDashboardPage>(this, MessagingServiceConstants.UPDATE_DIET_CHART_VIEW,
                    sender => OnAppearing()));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Content.IsVisible = true;  

            
            await DietChartViewModel.ExecuteLoadSeedDataCommand();  
        }
    }
}
