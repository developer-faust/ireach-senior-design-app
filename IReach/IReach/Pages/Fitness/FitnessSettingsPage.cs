using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Localization;
using IReach.ViewModels.Fitness;
using IReach.Views.Fitness;
using Xamarin.Forms;


namespace IReach.Pages.Fitness
{
    class FitnessSettingsPage : ContentPage
    {
        private StackLayout _stackLayout;
        private FitnessSettingsViewModel FitnessSettingsViewModel { get; set; }

        public View PropertyView
        {
            get { return (View)GetValue(PropertyViewProperty); }
            set { SetValue(PropertyViewProperty, value); }
        }

        public static readonly BindableProperty PropertyViewProperty = BindableProperty.Create("PropertyView", typeof(View), typeof(FitnessDashboardPage), null, propertyChanged: OnPropertyViewChanged);

        private static void OnPropertyViewChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            throw new NotImplementedException();
        }

        public FitnessSettingsPage ()
        {

            var fitnessSettingsView = new FitnessSettingsView()
            {
                BindingContext = FitnessSettingsViewModel = new FitnessSettingsViewModel(this.Navigation)
            };

            _stackLayout = new StackLayout()
            {
                Spacing = 0,
                Padding = 10
            };
            Content = _stackLayout;
        }

    }
}
