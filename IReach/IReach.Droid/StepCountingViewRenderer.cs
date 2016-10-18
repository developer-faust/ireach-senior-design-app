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
using System.IO;
using com.refractored.fab;
using IReach.Droid.Renderers;
using IReach.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(IReach.ViewModels.Fitness.FitnessChartViewModel), typeof(IReach.Droid.StepCountingViewRenderer))]
namespace IReach.Droid
{
    class StepCountingViewRenderer : ViewRenderer
    {

    }
}