﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using IReach.Pages.Fitness;
using IReach.ViewModels.Fitness;
using Xamarin.Forms;

namespace IReach.Pages
{
    public class FitnessLogPage : TabbedPage
    {
        public FitnessLogPage()
        {
            this.Children.Add(new FitnessDashboardPage());
            this.Children.Add(new  StepCountFitnessPage()
            {
                Title = "Steps Today",
                BindingContext = new StepCountViewModel(Navigation)
            });
            this.Children.Add(new FitnessGraphPage());
        }
         
    }
}
