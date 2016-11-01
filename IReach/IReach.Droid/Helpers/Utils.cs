using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IReach.Helpers;

namespace IReach.Droid.Helpers
{
    public static class Utils
    {
        public static bool IsKitKatWithStepCounter(PackageManager pm)
        {

            // Require at least Android KitKat
            int currentApiVersion = (int)Build.VERSION.SdkInt;
            // Check that the device supports the step counter and detector sensors
            return currentApiVersion >= 19
                && pm.HasSystemFeature(Android.Content.PM.PackageManager.FeatureSensorStepCounter)
                && pm.HasSystemFeature(Android.Content.PM.PackageManager.FeatureSensorStepDetector);

        }

        public static string DateString
        {
            get
            {
                var day = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                var dayNum = DateTime.Now.Day;
                if (Settings.UseKilometers)
                    return day + " " + dayNum + " " + month;

                return day + " " + month + " " + dayNum;
            }
        }

        public static string GetDateStaring(DateTime date)
        {
            string day = date.ToString("ddd");
            string month = date.ToString("MMM");
            int dayNum = date.Day;
            if (Settings.UseKilometers)
                return day + " " + dayNum + " " + month;

            return day + " " + month + " " + dayNum;
        }

        //public static bool IsSameDay
        //{
        //    get
        //    {
        //        return DateTime.Today.DayOfYear == Helpers.Settings.CurrentDay.DayOfYear &&
        //          DateTime.Today.Year == Helpers.Settings.CurrentDay.Year;
        //    }
        //}

        public static string FormatSteps(Int64 steps)
        {
            return steps.ToString("N0");
        }
    }
}