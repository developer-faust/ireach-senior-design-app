using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Localization;
using IReach.Statics;
using Xamarin.Forms;

namespace IReach.Views.Dashboard
{
    public class FitnessDashChartHeaderView : ContentView
    {
        readonly Label _WeeklyAverageValueLabel;

        public static readonly BindableProperty DailyStepsProperty = BindableProperty.Create<FoodDashChartHeaderView, string>(p => p.WeeklyAverage, null);

        public string DailySteps
        {
            get { return (string)GetValue(DailyStepsProperty); }
            set { SetValue(DailyStepsProperty, value); }
        }

        // Updates average weekly calorie 
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case "DailySteps":
                    _WeeklyAverageValueLabel.Text = (string)GetValue(DailyStepsProperty);
                    break;
            }
        }

        public FitnessDashChartHeaderView()
        {
            Label headerTitleLabel = new Label
            {
                Text = TextResources.Dashboard_Fitness_Header_Title,
                TextColor = Device.OnPlatform(Palette._006, Palette._006, Color.White),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start
            };

            Label DailyStepsCountTitleLabel = new Label()
            {
                Text = TextResources.DiaryDashboard_FoodChart_Header_WeeklyAverageTitle.ToUpperInvariant(),
                TextColor = Palette._006,
                FontSize = Device.OnPlatform(
                  iOS: Device.GetNamedSize(NamedSize.Micro, typeof(Label)) * .9,
                  Android: Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                  WinPhone: Device.GetNamedSize(NamedSize.Micro, typeof(Label))),
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.Center,
            };

            _WeeklyAverageValueLabel = new Label()
            {
                TextColor = Device.OnPlatform(Palette._006, Palette._006, Color.White),
                FontSize = Device.OnPlatform(
                    iOS: Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    Android: Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    WinPhone: Device.GetNamedSize(NamedSize.Large, typeof(Label))) * 1.1,
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.End
            };

            Device.OnPlatform(
                Android: () => _WeeklyAverageValueLabel.FontAttributes = FontAttributes.Bold);

            RelativeLayout relativeLayout = new RelativeLayout();

            relativeLayout.Children.Add(
                view: headerTitleLabel,
                xConstraint: Constraint.RelativeToParent(parent => 0),
                yConstraint: Constraint.RelativeToParent(parent => 0),
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
                heightConstraint: Constraint.RelativeToParent(parent => parent.Height)
            );

            relativeLayout.Children.Add(
                view: DailyStepsCountTitleLabel,
                xConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
                yConstraint: Constraint.RelativeToParent(parent => 0),
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
                heightConstraint: Constraint.RelativeToParent(parent => parent.Height / 4)
            );

            relativeLayout.Children.Add(
                view: _WeeklyAverageValueLabel,
                xConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
                yConstraint: Constraint.RelativeToParent(parent => parent.Height / 4),
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
                heightConstraint: Constraint.RelativeToParent(parent => (parent.Height / 4) * 3)
            );

            //BackgroundColor = Palette._002;

            //Device.OnPlatform(iOS: () => BackgroundColor = Color.White, Android: () => BackgroundColor = Palette._009);

            HeightRequest = RowSizes.MediumRowHeightDouble;

            Padding = new Thickness(10, 20, 10, 0);

            Content = relativeLayout;
        }
    }
}
