using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Support.V4.App;
using IReach.ViewModels.Fitness;
using IReach.Views.Base;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;
using System.Threading;

using Xamarin.Forms;

namespace IReach.Views.Fitness
{
    public partial class FitnessSettingsView : FitnessSettingsViewXaml
    {
        public FitnessSettingsViewModel ViewModel;
        public FitnessSettingsView()
        {
            InitializeComponent();
            BindingContext = ViewModel = new FitnessSettingsViewModel(this.Navigation);
            GoalValueLabel.Text = ViewModel.Goal.ToString();
            SensitivitySlider.BindingContext = ViewModel;
        }

        public void ChangeSensitivity(object sender, EventArgs e)
        {
            ViewModel.Sensitivity =(int) SensitivitySlider.Value;
            SensitivitySlider.Value = ViewModel.Sensitivity;
            sensativityLabel.Text = ViewModel.Sensitivity.ToString();
        }

        public void ResetButtonClicked(object sender, EventArgs e)
        {
            ViewModel.CurrentSteps = 0;
        }

        
    }

    public abstract class FitnessSettingsViewXaml : ModelBoundContentView<FitnessSettingsViewModel>
    {
    }
}
