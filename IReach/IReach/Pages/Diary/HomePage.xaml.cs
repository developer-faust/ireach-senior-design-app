using System;
using System.Diagnostics;
using CrossPieCharts.FormsPlugin.Abstractions;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace IReach.Pages.Diary
{
    public partial class HomePage : ContentPage
    {
        private IDeviceMotion motion = CrossDeviceMotion.Current;
        private Label totalCalories;
        private Entry TargetEntry;
        private CrossPieChartView chartView;
        private Label ChartLabel;
        public HomePage()
        {
            InitializeComponent(); 
            var lable1 = new Label
            {
                XAlign = TextAlignment.Center,
                Text = "Summary: ",
                TextColor = Color.Black
            };
            totalCalories = new Label();
            TargetEntry = new Entry();
            TargetEntry.Text = $"3000";


            Debug.WriteLine("Progress So Far {0}", Progress);


            chartView = new CrossPieChartView();
            chartView.Progress = (float)_progress;
            chartView.ProgressColor = Color.Green;
            chartView.ProgressBackgroundColor = Color.FromHex("#EEEEEEEE");
            chartView.StrokeThickness = Device.OnPlatform(10, 20, 80);
            chartView.Radius = Device.OnPlatform(100, 180, 160);
            chartView.BackgroundColor = Color.White;


            ChartLabel = new Label();
            ChartLabel.Text = string.Format("{0}", _progress);
            ChartLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            ChartLabel.FontAttributes = FontAttributes.Bold;
            ChartLabel.VerticalOptions = LayoutOptions.Center;
            ChartLabel.HorizontalOptions = LayoutOptions.Center;
            ChartLabel.TextColor = Color.Black;

            var mainGrid = new Grid
            {
                Children =
                {
                   chartView,
                   ChartLabel
                }
            };
            var graphsLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new CrossPieChartView
                    {
                        Progress = 80,
                        ProgressColor = Color.Blue,
                        ProgressBackgroundColor = Color.Gray,
                        StrokeThickness = Device.OnPlatform(10, 10, 20),
                        Radius = Device.OnPlatform(100, 50, 36),
                        BackgroundColor = Color.White
                    },
                    new CrossPieChartView
                    {
                        Progress = 55,
                        ProgressColor = Color.Olive,
                        ProgressBackgroundColor = Color.Gray,
                        StrokeThickness = Device.OnPlatform(10, 10, 20),
                        Radius = Device.OnPlatform(100, 50, 36),
                        BackgroundColor = Color.White
                    } 
                }
            };
            

            HomePageStackLayout.Children.Insert(0, lable1); 
            HomePageStackLayout.Children.Insert(1, mainGrid);
            HomePageStackLayout.Children.Insert(2, graphsLayout);  
            HomePageStackLayout.Children.Insert(3, totalCalories); 
            HomePageStackLayout.Children.Insert(4, TargetEntry); 
        }

        private double _totalCalories;
        public double TotalCalories { get { return _totalCalories; } set { _totalCalories = value; }}

        private double _progress;

        public double Progress
        {
            get { return _progress; }
            set
            {
                _progress = value; 
            }
        }
         

        private void OnStartActivated(object sender, EventArgs e)
        {
            motion.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Default);
            if (motion.IsActive(MotionSensorType.Accelerometer))
            {
                motion.SensorValueChanged += Motion_SensorValueChanged; 
            }
        }

        private void Motion_SensorValueChanged ( object sender, SensorValueChangedEventArgs e )
        {
            System.Diagnostics.Debug.WriteLine("X:{0}, Y:{1}, Z:{2}", 
                ((MotionVector)e.Value).X,
                ((MotionVector)e.Value).Y,
                ((MotionVector)e.Value).Z
            );

            Device.BeginInvokeOnMainThread(() =>
            {
                xLabel.Text = ((MotionVector) e.Value).X.ToString("0.0000");
                yLabel.Text = ( ( MotionVector )e.Value ).Y.ToString ( "0.0000" );
                zLabel.Text = ( ( MotionVector )e.Value ).Z.ToString ( "0.0000" );

            } );
        }

        private void OnStopActivated(object sender, EventArgs e)
        {
            motion.Stop(MotionSensorType.Accelerometer);
        }

        private void HomePage_OnAppearing(object sender, EventArgs e)
        {

            Debug.WriteLine("Page Appearing");
            _totalCalories = App.Database.TotalCalories();

            int target;
            int.TryParse(TargetEntry.Text, out target);
            _progress = (_totalCalories/target)* 100;

            ChartLabel.Text = string.Format("{0}", _progress);
            chartView.Progress = (float)_progress;


            totalCalories.Text = string.Format("Your total calories = {0} Target = {1} Progress = {2}", _totalCalories, target, _progress);
             
        }
    }
}
