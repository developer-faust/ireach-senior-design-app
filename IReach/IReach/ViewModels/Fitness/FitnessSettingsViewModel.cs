using System.Text;
using System.Threading.Tasks;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using IReach.Pages.Fitness;
using IReach.ViewModels.Base;
using IReach.Models;
using Xamarin.Forms;

namespace IReach.ViewModels.Fitness
{
    public class FitnessSettingsViewModel : BaseViewModel
    {
        
        private INavigation _navigation;
        public FitnessSettingsViewModel(INavigation nav) : base(nav)
        {
            _navigation = nav;
        }

        public double Goal
        {
            get { return StepCount.Steps.GetStepsGoal(); }
            set
            {
                StepCount.Steps.SetStepsGoal(value);
            }
        }

        private int _sensitivity;
        public int Sensitivity
        {
            get { return _sensitivity; }
            set
            {
                if (_sensitivity != value)
                {
                    _sensitivity = value;
                    CrossDeviceMotion.Current.Stop(MotionSensorType.StepCounter);
                    switch (value)
                    {
                        case 0:
                            CrossDeviceMotion.Current.Start(MotionSensorType.StepCounter);
                            break;
                        case 1:
                            CrossDeviceMotion.Current.Start(MotionSensorType.StepCounter, MotionSensorDelay.Default);
                            break;
                        case 2:
                            CrossDeviceMotion.Current.Start(MotionSensorType.StepCounter, MotionSensorDelay.Ui);
                            break;
                        case 3:
                            CrossDeviceMotion.Current.Start(MotionSensorType.StepCounter, MotionSensorDelay.Game);
                            break;
                        case 4:
                            CrossDeviceMotion.Current.Start(MotionSensorType.StepCounter, MotionSensorDelay.Fastest);
                            break;
                    }
                }               
                //OnPropertyChanged("Sensitivity");
            }
        }

        public double CurrentSteps
        {
            get { return StepCount.Steps.GetTotalSteps(); }
            set
            {
                StepCount.Steps.SetTotalSteps(value);
            }
        } 
    }
}
