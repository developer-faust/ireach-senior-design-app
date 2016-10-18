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

    public class FitnessDashboardPage : ContentPage
    {
        private StackLayout _frameStackLayout;
        private ToolbarItem toolbarItem;
        
        private FitnessChartViewModel FitnessChartViewModel { get; set; }

        public View PropertyView
        {
            get { return (View) GetValue(PropertyViewProperty); }
            set { SetValue(PropertyViewProperty, value);}
        }

        public static readonly BindableProperty PropertyViewProperty = BindableProperty.Create("PropertyView", typeof(View ), typeof(FitnessDashboardPage), null, propertyChanged: OnPropertyViewChanged);

        private static void OnPropertyViewChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            throw new NotImplementedException();
        }

        public FitnessDashboardPage()
        { 
            this.SetBinding(Page.TitleProperty, new Binding() {Source = TextResources.FitnessDashboardPage_Title});

            toolbarItem = new ToolbarItem()
            {
                Text = "Settings",
                Icon = "Setting.png"
            };

            toolbarItem.Clicked += toolbartItem_Clicked;
            ToolbarItems.Add(toolbarItem); 
            

            var fitnessChartView = new FitnessChartView()
            {
                BindingContext = FitnessChartViewModel = new FitnessChartViewModel(this.Navigation)
            };
             

            _frameStackLayout = new StackLayout()
            {
                Spacing = 0,
                Padding = 10,
                Children =
                {
                    fitnessChartView
                }
            };

            Content = _frameStackLayout;
        }

        private void toolbartItem_Clicked(object sender, EventArgs e)
        {
            if (toolbarItem.Text == "Settings")
            {
                Debug.WriteLine("Clicked Settings");

            }
        } 

    } 
}
