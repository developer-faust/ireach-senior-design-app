using Android.App;
using Android.OS;
using Android.Widget;

namespace IReach.Droid
{
    [Activity(Label = "MyFitnessActivity")]
    public class MyFitnessActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.FitnessLayout);

            var button = FindViewById<Button>(Resource.Id.myButton); 
            button.Click += (sender, e) => {
                Finish(); // back to the previous activity
            };
            // Create your application here  
        }
    }
}