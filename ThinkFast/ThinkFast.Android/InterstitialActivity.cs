using Huawei.Hms.Ads;
using ThinkFast.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThinkFast.Droid.InterstitialActivity))]
namespace ThinkFast.Droid
{
    public class InterstitialActivity : IHuaweiAds
    {
        private InterstitialAd interstitialAd;

        public void LoadInterstitialAd()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);
            interstitialAd.AdId = "a9s7snw11g"; //testb4znbuh3n2 is a dedicated test ad slot ID.
            AdParam adParam = new AdParam.Builder().Build();
            interstitialAd.LoadAd(adParam);
        }

        public void ShowInterstitial()
        {
            // Display an interstitial ad.
            if (interstitialAd != null && interstitialAd.IsLoaded)
            {
                interstitialAd.Show();
            }
            else
            {
                // The ad was not loaded.
            }
        }
    }
}