using ThinkFast.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThinkFast.Droid.Localize))]
namespace ThinkFast.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");

            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}