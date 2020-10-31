using Android.Preferences;
using ThinkFast.Services;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(ThinkFast.Droid.Pref))]
namespace ThinkFast.Droid
{
    public class Pref : IPref
    {
        public bool GetPref()
        {
            var pref = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
           
            return pref.GetBoolean("firstTime", true);
        }

        public void SavePref()
        {
            var pref = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            var editorLogin = pref.Edit();
            editorLogin.PutBoolean("firstTime", false).Commit();
        }
    }
}