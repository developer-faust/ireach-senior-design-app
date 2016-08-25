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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using IReach.Views;


[assembly:ExportRenderer(typeof(IReach.Views.AboutPage), typeof(IReach.Droid.AboutPageRenderer))]
namespace IReach.Droid
{
    public class AboutPageRenderer : PageRenderer
    {

        Android.Views.View view; 

        protected override void OnElementChanged ( ElementChangedEventArgs<Page> e )
        {
            base.OnElementChanged ( e );

            var page = e.NewElement as AboutPage;

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            ImageView imageView = FindViewById<ImageView> ( Resource.Id.imageView );

           

            var o = activity.LayoutInflater.Inflate ( Resource.Layout.AboutPage, this, false );
            view = o;
            
            var label = view.FindViewById<TextView> ( Resource.Id.textView1 );
            label.Text = page.Heading;

          

            AddView ( view );
        }

        protected override void OnLayout ( bool changed, int l, int t, int r, int b )
        {
            base.OnLayout ( changed, l, t, r, b );
            var msw = MeasureSpec.MakeMeasureSpec ( r - l, MeasureSpecMode.Exactly );
            var msh = MeasureSpec.MakeMeasureSpec ( b - t, MeasureSpecMode.Exactly );
            view.Measure ( msw, msh );
            view.Layout ( 0, 0, r - l, b - t );
        }

    }
}