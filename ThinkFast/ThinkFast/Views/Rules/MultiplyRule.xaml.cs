using System;
using ThinkFast.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views.Rules
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiplyRule : ContentPage
    {
        private static readonly Color color = Color.FromRgb(232, 232, 240);

        public MultiplyRule()
        {
            InitializeComponent();
            var four = GetFrame(AppResources.Multiplication4Message, "33 × 4 = 66 × 2 = 132");
            var five2 = GetFrame(AppResources.Multiplication5_2Message, "86 × 5 = 86 ÷ 2 × 10 = 430");
            var five = GetFrame(AppResources.Multiplication5Message, "43 × 5 = 43 × 10 ÷ 2 = 215");
            var eight = GetFrame(AppResources.Multiplication8Message, "51 × 8 = 102 × 2 = 204 × 2 = 408");
            var nine = GetFrame(AppResources.Multiplication9Message, "22 × 9 = 22 × 10 - 22 = 220 - 22 = 198");
            var multiOne = GetFrame(AppResources.MultiplicationMultyOneMessage, "47 × 4 = 40 × 4 + 7 × 4 = 188");
            var eleven = GetFrame(AppResources.Multiplication11Message, "87 × 11 = 870 × 10 + 87 = 957");
            var multi25 = GetFrame(AppResources.Multiplication25Message, "65 × 25 = 65 × 100 ÷ 4 = 1625");
            var multi25_4 = GetFrame(AppResources.Multiplication25_4Message, "92 × 25 = 92 ÷ 4 × 100 = 2300");
            var multi = GetFrame(AppResources.MultiplicationMultyMessage, "18 × 78 = 18 × 7 × 10 + 18 × 8 = 1404");

            var goBackButton = new Button
            {
                Text = AppResources.Back,
                BackgroundColor = Color.FromRgb(112, 144, 160),
                Margin = new Thickness(0, 16, 0, 16),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 130
            };
            goBackButton.Clicked += GoBackButtonOnClicked;

            

            var stack = new StackLayout
            {
                Children = { four, five2, five, eight, nine, multiOne, eleven, multi25, multi25_4, multi, goBackButton },
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