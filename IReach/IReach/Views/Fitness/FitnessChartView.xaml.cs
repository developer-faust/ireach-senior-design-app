﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Support.V4.App;
using IReach.ViewModels.Fitness;
using IReach.Views.Base;
using Xamarin.Forms;
using System.Threading;

namespace IReach.Views.Fitness
{
    public partial class FitnessChartView : FitnessChartViewXaml
    {

        public FitnessChartViewModel ViewModel;
        private ToolbarItem toolbarItem;

        public FitnessChartView ( )
        {
            InitializeComponent ( );

            BindingContext = ViewModel = new FitnessChartViewModel(this.Navigation);

            CircularGauge.BindingContext = ViewModel;

      
            
            // Header position
            TitleHeader.Position = Device.OnPlatform(iOS: new Point(0.5, 0.65), Android: new Point(0.5, 0.65), WinPhone:new Point(0.5, 0.65));
            ValueHeader.Position = Device.OnPlatform(iOS: new Point(0.5, 0.75), Android: new Point(0.5, 0.75), WinPhone: new Point(0.5, 0.75));
            UnitsHeader.Position = Device.OnPlatform(iOS: new Point(0.5, 0.85), Android: new Point(0.5, 0.85), WinPhone: new Point(0.5, 0.85));

            // TODO: Change Target set by User 
            ViewModel.TargetSteps = 3000;     

            // TODO: The Steps Counted So Far set by the Step service
            ViewModel.StepsCount = 400;

            

            PercentCompleteLabel.Text = ViewModel.Complete.ToString();
            Debug.WriteLine("Percent Completed {0}", ViewModel.Complete);
        }
    }

    public abstract class FitnessChartViewXaml : ModelBoundContentView<FitnessChartViewModel>
    {
    }
}
