using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPieCharts.FormsPlugin.Abstractions;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace IReach.Views
{
    public partial class HomePage : ContentPage
    {
        private IDeviceMotion motion = CrossDeviceMotion.Current;

        public HomePage()
        {
            InitializeComponent();

            var lable1 = new Label
            {
                XAlign = TextAlignment.Center,
                Text = "Summary: ",
                TextColor = Color.Black
            };
            
            var mainGrid = new Grid
            {
                Children =
                {
                    new CrossPieChartView
                    {
                        Progress = 60,
                        ProgressColor = Color.Green,
                        ProgressBackgroundColor = Color.FromHex("#EEEEEEEE"),
                        StrokeThickness = Device.OnPlatform(10, 20, 80),
                        Radius = Device.OnPlatform(100, 180, 160),
                        BackgroundColor = Color.White
                    },
                    new Label
                    {
                        Text = "60%", 
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.Black
                    }
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
         
    }
}
