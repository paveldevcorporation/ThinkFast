using System;
using Android.Content;
using Android.Gms.Ads;
using Android.Gms.Ads.Formats;
using Android.Views;
using Android.Widget;
using ThinkFast.Droid;
using ThinkFast.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ThinkFast.Views.NativeAdView), typeof(NativeAdViewRenderer))]

namespace ThinkFast.Droid
{
    public class NativeAdViewRenderer : ViewRenderer
    {
        public NativeAdViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var adLoader = new AdLoader.Builder(Context, AdConsts.NativeId);

                var listener = new UnifiedNativeAdLoadedListener();
                listener.OnNativeAdLoaded += (s, ad) =>
                {
                    try
                    {
                        var root = new UnifiedNativeAdView(Context);
                        var inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
                        var adView = (UnifiedNativeAdView)inflater.Inflate(Resource.Layout.ad_unified, root);

                        populateUnifiedNativeAdView(ad, adView);

                        SetNativeControl(adView);
                    }
                    catch
                    {

                    }
                };

                adLoader.ForUnifiedNativeAd(listener);
                var requestBuilder = new AdRequest.Builder();
                adLoader.Build().LoadAd(requestBuilder.Build());
            }
        }

        private void populateUnifiedNativeAdView(UnifiedNativeAd nativeAd, UnifiedNativeAdView adView)
        {
            adView.MediaView = adView.FindViewById<MediaView>(Resource.Id.ad_media);

            // Set other ad assets.
            adView.HeadlineView = adView.FindViewById<TextView>(Resource.Id.ad_headline);
            adView.BodyView = adView.FindViewById<TextView>(Resource.Id.ad_body);
            adView.CallToActionView = adView.FindViewById<TextView>(Resource.Id.ad_call_to_action);
            adView.IconView = adView.FindViewById<ImageView>(Resource.Id.ad_app_icon);
            adView.PriceView = adView.FindViewById<TextView>(Resource.Id.ad_price);
            adView.StarRatingView = adView.FindViewById<RatingBar>(Resource.Id.ad_stars);
            adView.StoreView = adView.FindViewById<TextView>(Resource.Id.ad_store);
            adView.AdvertiserView = adView.FindViewById<TextView>(Resource.Id.ad_advertiser);

            // The headline and mediaContent are guaranteed to be in every UnifiedNativeAd.
            ((TextView)adView.HeadlineView).Text = nativeAd.Headline;

            // These assets aren't guaranteed to be in every UnifiedNativeAd, so it's important to
            // check before trying to display them.
            if (nativeAd.Body == null)
            {
                adView.BodyView.Visibility = ViewStates.Invisible;
            }
            else
            {
                adView.BodyView.Visibility = ViewStates.Visible;
                ((TextView)adView.BodyView).Text = nativeAd.Body;
            }

            if (nativeAd.CallToAction == null)
            {
                adView.CallToActionView.Visibility = ViewStates.Invisible;
            }
            else
            {
                adView.CallToActionView.Visibility = ViewStates.Visible;
                ((Android.Widget.Button)adView.CallToActionView).Text = nativeAd.CallToAction;
            }

            if (nativeAd.Icon == null)
            {
                adView.IconView.Visibility = ViewStates.Gone;
            }
            else
            {
                ((ImageView)adView.IconView).SetImageDrawable(nativeAd.Icon.Drawable);
                adView.IconView.Visibility = ViewStates.Visible;
            }

            if (string.IsNullOrEmpty(nativeAd.Price))
            {
                adView.PriceView.Visibility = ViewStates.Gone;
            }
            else
            {
                adView.PriceView.Visibility = ViewStates.Visible;
                ((TextView)adView.PriceView).Text = nativeAd.Price;
            }

            if (nativeAd.Store == null)
            {
                adView.StoreView.Visibility = ViewStates.Invisible;
            }
            else
            {
                adView.StoreView.Visibility = ViewStates.Visible;
                ((TextView)adView.StoreView).Text = nativeAd.Store;
            }

            if (nativeAd.StarRating == null)
            {
                adView.StarRatingView.Visibility = ViewStates.Invisible;
            }
            else
            {
                ((RatingBar)adView.StarRatingView).Rating = nativeAd.StarRating.FloatValue();
                adView.StarRatingView.Visibility = ViewStates.Visible;
            }

            if (nativeAd.Advertiser == null)
            {
                adView.AdvertiserView.Visibility = ViewStates.Invisible;
            }
            else
            {
                ((TextView)adView.AdvertiserView).Text = nativeAd.Advertiser;
                adView.AdvertiserView.Visibility = ViewStates.Visible;
            }

            // This method tells the Google Mobile Ads SDK that you have finished populating your
            // native ad view with this native ad.
            adView.SetNativeAd(nativeAd);
        }
    }

    public class UnifiedNativeAdLoadedListener : AdListener, UnifiedNativeAd.IOnUnifiedNativeAdLoadedListener
    {
        public void OnUnifiedNativeAdLoaded(UnifiedNativeAd ad)
        {
            OnNativeAdLoaded?.Invoke(this, ad);
        }

        public EventHandler<UnifiedNativeAd> OnNativeAdLoaded { get; set; }
    }
}
