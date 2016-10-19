﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Fitness
{
    public class StepCountViewModel : BaseViewModel
    {

        public string _steps;

        public string Steps
        {
            get
            {
                return _steps;
            }
            set
            {
                _steps = value;
                OnPropertyChanged("Steps");
            }
        }

        public StepCountViewModel(INavigation navigation = null) : base(navigation)
        {

            CrossDeviceMotion.Current.Start(MotionSensorType.StepCounter);
            CrossDeviceMotion.Current.SensorValueChanged += Current_SensorValueChanged;

        }

        private void Current_SensorValueChanged(object sender, SensorValueChangedEventArgs e)
        {


            switch (e.SensorType)
            {
                    case MotionSensorType.StepCounter:
                        Steps = e.Value.ToString();
                    Debug.WriteLine("Steps Count Changed: {0}", e.Value.Value);
                        break;
                    
            }
        }
    }
}
