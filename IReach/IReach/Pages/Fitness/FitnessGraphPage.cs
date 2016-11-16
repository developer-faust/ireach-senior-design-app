using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Localization;
using IReach.Statics;
using IReach.ViewModels.Fitness;
using IReach.Views.Fitness;
using Xamarin.Forms;

namespace IReach.Pages.Fitness
{
    class FitnessGraphPage : ContentPage
    {
        private StackLayout contentframe;
        private FitnessGraphViewModel FitnessGraphVM { get; set; }

        public FitnessGraphPage()
        {
            //this.SetBinding(Page.TitleProperty, new Binding() {Source=TextResources.} ask about this line

            var fitnessGraphView = new FitnessGraphView()
            {
                BindingContext = FitnessGraphVM = new FitnessGraphViewModel(Navigation)
            };
            Content = fitnessGraphView;

            /*Device.OnPlatform(
                Android: () => MessagingCenter.Subscribe<FitnessGraphPage>(this, MessagingServiceConstants.UPDATE_DIET_CHART_VIEW,
                    sender => OnAppearing())); Ask about this as well */
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing();
            Content.IsVisible = true;
        }

    }
}
