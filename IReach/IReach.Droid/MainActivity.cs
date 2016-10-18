using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using IReach.Pages.Fitness;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace IReach.Droid
{
	[Activity ( Label = "IReach", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate ( Bundle bundle )
		{
            base.OnCreate(bundle); 
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;

			global::Xamarin.Forms.Forms.Init ( this, bundle );
            ImageCircleRenderer.Init();
			LoadApplication ( new App ( ) ); 
        } 

        
    }
}

