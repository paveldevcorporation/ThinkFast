using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarcTron.Plugin.Controls;
using ThinkFast.Resources;
using ThinkFast.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views.Rules
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinusRule : ContentPage
    {
        private static readonly Color color = Color.FromRgb(232, 232, 240);
        readonly IFirebaseAnalyticsService analyticsService = DependencyService.Get<IFirebaseAnalyticsService>();

        public MinusRule()
        {
            InitializeComponent();
            analyticsService.LogEvent("minus_rule");
            var frame1To20 = GetFrame(AppResources.Subtraction1To20Rule, "14 - 6 = 14 - 4 - 2 = 8");
            var frame7 = GetFrame(AppResources.Minus7Message, "55 - 7 = 55 - 10 + 3 = 48");
            var frame8 = GetFrame(AppResources.Minus8Message, "66 - 8 = 66 - 10 + 2 = 58");
            var frame9 = GetFrame(AppResources.Minus9Message, "67 - 9 = 67 - 10 + 1 = 58");
            var frameMulti = GetFrame(AppResources.MinusMultiMessage, "33 - 15 = 33 - 10 - 5 = 18");

            var goBackButton = new Button
            {
                Text = AppResources.Back,
                BackgroundColor = Color.FromRgb(112, 144, 160),
                Margin = new Thickness(0, 16, 0, 16),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 130
            };
            goBackButton.Clicked += GoBackButtonOnClicked;

            var ads = new MTAdView
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
                Children = { frame1To20, frame7, frame8, frame9, frameMulti, goBackButton, ads },
                BackgroundColor = Color.FromRgb(232, 232, 240)
            };

            Content = new ScrollView { Content = stack }; ;
        }

        private static Frame GetFrame(string rule, string example)
        {
            var frame = new Frame { CornerRadius = 5, Padding = 8, BorderColor = color, Margin = new Thickness(5) };
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