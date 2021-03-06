using System;
using MarcTron.Plugin;
using MarcTron.Plugin.Controls;
using ThinkFast.Resources;
using ThinkFast.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views.Rules
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRule : ContentPage
    {
        private static readonly Color color = Color.FromRgb(232, 232, 240);
        readonly IFirebaseAnalyticsService analyticsService = DependencyService.Get<IFirebaseAnalyticsService>();

        public AddRule()
        {
            InitializeComponent();
            analyticsService.LogEvent("plus_rule");
            var frameAddition1To20 = GetFrame(AppResources.Addition1To20Rule, "7 + 6 = 7 + 3 + 3 = 13");
            var frame789 = GetFrame(AppResources.Plus_7_8_9_Message, "68 + 7 = 68 + 10 - 3 = 75");
            var frameMulti = GetFrame(AppResources.PlusMultiMessage, "45 + 17 = (40 + 10) + (5 + 7) = 62");

            var goBackButton = new Button
            {
                Text = AppResources.Back,
                BackgroundColor = Color.FromRgb(112, 144, 160),
                Margin = new Thickness(0, 16, 0, 16),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 130
            };
            goBackButton.Clicked += GoBackButtonOnClicked;

            var ads = new MTAdView()
            {
#if DEBUG
                AdsId = "ca-app-pub-3940256099942544/6300978111",
#else
                AdsId = "ca-app-pub-6005536417008283/9224083823",
#endif
                VerticalOptions = LayoutOptions.EndAndExpand
            };


            var stack = new StackLayout
            {
                Children = { frameAddition1To20, frame789, frameMulti, goBackButton, ads },
                BackgroundColor = Color.FromRgb(232, 232, 240)
            };

            Content = new ScrollView { Content = stack };
        }

        private static Frame GetFrame(string rule, string example)
        {
            var frame = new Frame {CornerRadius = 5, Padding = 8, BorderColor = color, Margin = new Thickness(5)};
            var messageStack = new StackLayout();

            var message = new Label
            {
                Text = rule,
                FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            var line = new BoxView
            {
                Color = color,
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.Fill
            };

            var solution = new Label
            {
                Text = example,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            messageStack.Children.Add(message);
            messageStack.Children.Add(line);
            messageStack.Children.Add(solution);

            frame.Content = messageStack;
            return frame;
        }


        private void GoBackButtonOnClicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopModalAsync();
        }
    }
}