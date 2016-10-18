using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IReach.Droid.Services
{
    public class StepServiceBInder : Binder
    {
        StepCountingService stepService;

        public StepServiceBInder(StepCountingService service)
        {
            this.stepService = service;
        }

        public StepCountingService StepService
        {
            get { return stepService; }
        }
    }
}