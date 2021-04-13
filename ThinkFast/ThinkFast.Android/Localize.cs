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
            var prefLanguage = "en-US";
            var prefLanguageRu = "ru-RU";

            System.Globalization.CultureInfo ci = null;
            try
            {
                
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch
            {
                var lang = netLanguage.Contains("ru") ? prefLanguageRu : prefLanguage;
                ci = new System.Globalization.CultureInfo(lang);
            }
            return ci;
        }
    }
}