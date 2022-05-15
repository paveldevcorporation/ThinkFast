using Xamarin.Forms;

namespace ThinkFast.Views
{
    public class NativeAdView : ContentView
    {
        public NativeAdView()
        {
            this.HeightRequest = 300;
            this.Margin = new Thickness(8, 50, 8, 20);

            SetPlaceholderContent();
        }

        private void SetPlaceholderContent()
        {
            var placeholderGrid = new Grid();
            var placeHolderText = new Label
            {
                FontSize = 48,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                Opacity = 0.3,
                VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true)
            };

            placeholderGrid.Children.Add(placeHolderText);

            this.Content = placeholderGrid;
        }
    }

}