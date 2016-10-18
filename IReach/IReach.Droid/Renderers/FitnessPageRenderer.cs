using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using IReach.Droid.Controls;
using IReach.Droid.Helpers;
using IReach.Droid.Renderers;
using IReach.Droid.Services;
using IReach.Pages.Fitness;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly:ExportRenderer(typeof(MyFitnessPage), typeof(FitnessPageRenderer))]
namespace IReach.Droid.Renderers
{
    public class FitnessPageRenderer : PageRenderer
    {
        private Android.Views.View view;
        public bool IsBound { get; set; } 
        private bool registered;
        private string calorieString, distanceString, percentString, completedString; 
        private FrameLayout topLayer;
        private bool canAnimate = true;
        private bool fullAnimation = true;
        private Handler handler;
        private bool firstRun = true;
        private ImageView highScore, warning;
        private ProgressView progressView;

        private TranslateAnimation animation;

        private StepServiceBInder binder;
        public StepServiceBInder Binder
        {
            get { return binder; }
            set
            {
                binder = value;
                if (binder == null)
                {
                    return;
                }

                HandlePropertyChanged(null, new System.ComponentModel.PropertyChangedEventArgs("StepsToday"));

                if (registered)
                {
                    binder.StepService.PropertyChanged -= HandlePropertyChanged;
                }

                binder.StepService.PropertyChanged += HandlePropertyChanged;
                registered = true;
            }
        }

        private void StartStepService()
        {
            try
            {
                var service = new  Intent(activity, typeof(StepCountingService));
                var componentName = activity.StartService(service); 
            }
            catch (Exception ex)
            { 
            }
        }

        private void AnimateTopLayer(float percent, bool force = false)
        {
            if(!canAnimate)
                return;

            if (height <= 0)
            {
                height = (float) topLayer.MeasuredHeight;
                if (height <= 0)
                {
                    return;
                }

            }

            canAnimate = false;

            var start = animation == null ? -height : lastY;
            var time = 300;
            IInterpolator interpolator;

            if (percent < 0)
            {
                percent = 0;
            }
            else if (percent > 100)
            {
                percent = 100;
            }

            lastY = -height*(percent/100F);

            if ((int)lastY == (int)start && !force)
            {
                canAnimate = true;
                return;
            }

            if (fullAnimation || !Utils.IsSameDay)
            {
                interpolator = new BounceInterpolator();
                time = 300;
                fullAnimation = false;

            }
            else
            {
                interpolator = new LinearInterpolator();
            }

            animation = new TranslateAnimation(Dimension.Absolute, 0,
                Dimension.Absolute, 0,
                Dimension.Absolute, (float)start,
                Dimension.Absolute, lastY);

            animation.Duration = time;

            animation.Interpolator = interpolator;
            animation.AnimationEnd += (object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e) =>
            {
                canAnimate = true;
            };

            animation.FillAfter = true;
            topLayer.StartAnimation(animation);

            if (topLayer.Visibility != Android.Views.ViewStates.Visible)
            {
                topLayer.Visibility = Android.Views.ViewStates.Visible;
            }

        }

        
        void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }
        //private int testSteps = 1;
        private TextView stepCount, calorieCount, distance, percentage; 
        private float height, lastY;
        private Activity activity;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var page = e.NewElement as MyFitnessPage;

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            activity = this.Context as Activity;
            var o = activity.LayoutInflater.Inflate(Resource.Layout.FitnessLayout, this, false);  
            view = o;

            topLayer = view.FindViewById<FrameLayout>(Resource.Id.top_layer);
            stepCount = view.FindViewById<TextView>(Resource.Id.stepcount);
            calorieCount = view.FindViewById<TextView>(Resource.Id.calories);
            distance = view.FindViewById<TextView>(Resource.Id.distance);
            percentage = view.FindViewById<TextView>(Resource.Id.percentage);
            progressView = view.FindViewById<ProgressView>(Resource.Id.progressView);
            highScore = view.FindViewById<ImageView>(Resource.Id.high_score);
            warning = view.FindViewById<ImageView>(Resource.Id.warning);

            calorieString = Resources.GetString(Resource.String.calories); 
            /*
                        ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView);  

                        var label = view.FindViewById<TextView>(Resource.Id.textView1);
                        label.Text = page.Heading;*/

            AddView(view);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }
    }
     
}
