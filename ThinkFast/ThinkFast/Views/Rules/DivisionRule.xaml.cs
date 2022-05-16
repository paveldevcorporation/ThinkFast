using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkFast.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views.Rules
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DivisionRule : ContentPage
    {
        private static readonly Color color = Color.FromRgb(232, 232, 240);

        public DivisionRule()
        {
            InitializeComponent();
            var four = GetFrame(AppResources.Division4Message, "48 ÷ 4 = 24 ÷ 2 = 12");
            var five = GetFrame(AppResources.Division5Message, "230 ÷ 5 = 460 ÷ 10 = 46");
            var eight = GetFrame(AppResources.Division8Message, "488 ÷ 8 = 244 ÷ 2 = 122 ÷ 2 = 61");
            var one = GetFrame(AppResources.DivisionOneMessage, "94 ÷ 2 = 90 ÷ 2 + 4 ÷ 2 = 47");

            var goBackButton = new Button
            {
                Text = AppResources.Back,
                BackgroundColor = Color.FromRgb(112, 144, 160),
                Margin = new Thickness(0, 16, 0, 16),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 130
            };
            goBackButton.Clicked += GoBackButtonOnClicked;

            //var adMod = new NativeAdView();

            var stack = new StackLayout
            {
                Children = { four, five, eight, one, goBackButton },
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