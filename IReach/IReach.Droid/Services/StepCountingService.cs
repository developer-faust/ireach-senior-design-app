using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.ComponentModel;

using Android.App;
using Android.Content;
using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
using Android.Hardware;


namespace IReach.Droid.Services
{
    [Service(Enabled = true)]
    [IntentFilter(new String[] { "com.refractored.IReach.StepService" })]
    public class StepCountingService : Service, ISensorEventListener, INotifyPropertyChanged
    {
        public int prevSteps { get; set; }
        public int TodaySteps { get; set; }
        private Binder binder;
        DateTime currentDay;
        void RegisterListener ()
        {
            var sm = (SensorManager)GetSystemService(Context.SensorService);
            var sensor = sm.GetDefaultSensor(SensorType.StepCounter);
            sm.RegisterListener(this, sensor, SensorDelay.Normal);
        }

        public void OnSensorChanged (SensorEvent e)
        {
            if (e.Sensor.Type == SensorType.StepCounter)
            {
                if (prevSteps < 0)
                {
                    prevSteps = 0;
                }
                int numsteps = (int)e.Values[0];
                if (numsteps < 0) //left on too long (4 days?)
                {
                    numsteps = prevSteps + 3;
                    SwitchtoStepDetector();
                }
                TodaySteps += numsteps;
            }
            else if (e.Sensor.Type == SensorType.StepDetector)
            {
                TodaySteps += prevSteps + 1;
            }
        }

        void SwitchtoStepDetector()
        {
            var sm = (SensorManager)GetSystemService(Context.SensorService);
            sm.UnregisterListener(this);
            var sensor = sm.GetDefaultSensor(SensorType.StepDetector);
            sm.RegisterListener(this, sensor, SensorDelay.Normal);
        }

        public void OnAccuracyChanged(Sensor s, SensorStatus a) { }
        public override Android.OS.IBinder OnBind (Android.Content.Intent i) //does nothing for now, can be fixed later if needed
        {
            binder = new Binder();
            return binder;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        //public void
        private void Start()
        {
            DateTime now = DateTime.UtcNow;
            if (currentDay == null)
            {
                currentDay = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day), DateTimeKind.Utc);
            }
            else
            {
                CheckDate(now);
            }
        }

        private void CheckDate(DateTime day)
        {
            //implemented later
        }
    }
}