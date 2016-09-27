using System.Globalization;
using IReach.Droid.Localization; 
using IReach.Localization;
using Xamarin.Forms;

[assembly:Dependency(typeof(Localize))]
namespace IReach.Droid.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");

            return new CultureInfo(netLanguage);
        }
    }
}