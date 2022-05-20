using Xamarin.Forms;

namespace ThinkFast.Views
{
    public class NativeAdView : ContentView
    {
        public NativeAdView()
        {
            this.HeightRequest = 300;
            this.Margin = new Thickness(8, 50, 8, 20);
            this.VerticalOptions = LayoutOptions.EndAndExpand;

            SetPlaceholderContent();
        }

        private void SetPlaceholderContent()
        {
            var placeholderGrid = new Grid();

            this.Content = placeholderGrid;
        }
    }
}