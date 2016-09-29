using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Converters;
using IReach.Localization;
using IReach.Statics;
using IReach.ViewModels.Diary;
using IReach.Views.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace IReach.Views.Diary
{
    public class DiaryDashboardChartView : ModelBoundContentView<DiaryDashboardChartViewModel>
    {
        public DiaryDashboardChartView()
        {
            var chartHeaderView = new DiaryChartHeaderView() {HeightRequest = RowSizes.MediumRowHeightDouble, Padding = new Thickness(20, 10, 20, 0)};
            chartHeaderView.SetBinding(DiaryChartHeaderView.WeeklyAverageProperty, "AverageWeeklyCalories");

            chartHeaderView.SetBinding(IsEnabledProperty, "IsBusy", converter: new InverseBooleanConverter());
            chartHeaderView.SetBinding(IsVisibleProperty, "IsBusy", converter: new InverseBooleanConverter());

            #region activity indicator
            var chartActivityIndicator = new ActivityIndicator()
            {
                HeightRequest = RowSizes.MediumRowHeightDouble
            };

            chartActivityIndicator.SetBinding(IsEnabledProperty, "IsBusy");
            chartActivityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            chartActivityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            #endregion

            #region loading label
            Label loadingLabel = new Label()
            {
                Text = TextResources.DiaryDashboard_FoodChart_LoadingLabel,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label) ),
                HeightRequest = RowSizes.MediumRowHeightDouble,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End,
                TextColor = Palette._007
            };

            loadingLabel.SetBinding(IsEnabledProperty, "IsBusy");
            loadingLabel.SetBinding(IsVisibleProperty, "IsBusy");
            #endregion

            #region Calories Graph

            double chartHeight = Device.OnPlatform(190, 300, 190);
            var columnSeries = new ColumnSeries()
            {
                YAxis = new NumericalAxis()
                {
                    Title = new ChartAxisTitle()
                    {
                        Text = TextResources.DiaryDashboard_FoodChart_YAxis_Title,
                        Font = ChartAxisFont,
                        TextColor = Palette._011
                    },
                    OpposedPosition = false,
                    ShowMajorGridLines = true,
                    MajorGridLineStyle = new ChartLineStyle() { StrokeColor = AxisLineColor },
                    ShowMinorGridLines = true,
                    MinorTicksPerInterval = 1,
                    MinorGridLineStyle = new ChartLineStyle() { StrokeColor = AxisLineColor },
                    LabelStyle = new ChartAxisLabelStyle()
                    {
                        TextColor = AxisLabelColor 
                    }
                },
                DataMarker = new ChartDataMarker()
                {
                    LabelStyle = new DataMarkerLabelStyle()
                    {
                        LabelPosition = DataMarkerLabelPosition.Auto,
                        TextColor = Color.Lime,
                        BackgroundColor = Color.Transparent
                    }
                },
                DataMarkerPosition = DataMarkerPosition.Top,
                EnableDataPointSelection = false,
                Color = Palette._003
            };


            // Bind data points to the chart
            columnSeries.SetBinding(ChartSeries.ItemsSourceProperty, "WeeklyCaloriesChartDataPoints");


            var chart = new SfChart()
            {
                HeightRequest = chartHeight,

                PrimaryAxis = new CategoryAxis()
                {
                    Title = new ChartAxisTitle()
                    {
                        Text = TextResources.DiaryDashboard_FoodChart_PrimaryAxis_Title,
                        Font = ChartAxisFont,
                        TextColor = Palette._011
                    },

                    LabelRotationAngle = -45,
                    EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Center,
                    LabelPlacement = LabelPlacement.BetweenTicks,
                    TickPosition = AxisElementPosition.Inside,
                    ShowMajorGridLines = false,
                    LabelStyle = new ChartAxisLabelStyle() { TextColor = Color.Red} 
                }
            };

            if (Device.OS == TargetPlatform.Android)
            {
                chart.BackgroundColor = Color.Transparent;
            }

            chart.Series.Add(columnSeries);
            chart.SetBinding(IsEnabledProperty, "IsBusy", converter: new InverseBooleanConverter());
            chart.SetBinding(IsVisibleProperty, "IsBusy", converter: new InverseBooleanConverter());

            StackLayout stackLayout = new StackLayout()
            {
                Spacing = 0,
                Children =
                {
                    loadingLabel,
                    chartActivityIndicator,
                    chartHeaderView,
                    new ContentView() {Content = chart, HeightRequest = chartHeight }
                }
            };
            #endregion


            #region platform adjustments
            Device.OnPlatform(
                iOS: () =>
                {
                    columnSeries.DataMarker.LabelStyle.Font = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Micro, typeof(Label)) * 0.6);
                },
                Android: () =>
                {
                    columnSeries.YAxis.LabelStyle.Font = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Micro, typeof(Label)) * 1.5);
                    columnSeries.DataMarker.LabelStyle.Font = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Micro, typeof(Label)) * 1.2);
                    chart.PrimaryAxis.LabelStyle.Font = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Micro, typeof(Label)) * 1.5);
                });
            #endregion

            Content = stackLayout;
        }

        public Color AxisLabelColor { get { return Device.OnPlatform(Palette._002, Palette._002, Color.White); } }

        static Color AxisLineColor { get { return Device.OnPlatform(Palette._008, Palette._008, Color.White); } }
        
        // Controls FontSize of axis titles 
        public Font ChartAxisFont
        {
            get
            {
                if (Device.OS == TargetPlatform.iOS)
                {
                    return Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Default, typeof(ChartAxisTitle)) * 0.6);
                }
                else if (Device.OS == TargetPlatform.Android)
                { 
                    return Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Default, typeof(ChartAxisTitle)));
                }
                else
                {
                    return Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Default, typeof(ChartAxisTitle)));
                }
            }
        }
    }
}
