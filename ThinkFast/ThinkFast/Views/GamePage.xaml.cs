using System;
using ThinkFast.Models;
using ThinkFast.Models.Games;
using ThinkFast.Models.Games.LevelTypes;
using ThinkFast.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private static int r = 112;
        private static int g = 144;
        private static int b = 160;
        private Label answer;
        private readonly Color color;
        private GameExample example;
        private ProgressBar progressBar;
        private Label question;
        private LevelType levelType;
        private int levelId = 1;
        private int step = 0;


        public GamePage()
        {
            InitializeComponent();
            r = 112;
            g = 144;
            b = 160;
            color = Color.FromRgb(r, g, b);
            levelType = LevelType.Get(levelId);
            StartGame();
        }

        private void StartGame()
        {
            Content = GetGrid();

            StartAnimate();
        }

        private void StartAnimate()
        {
            progressBar.Progress = 0;
            progressBar.ProgressColor = color;
            progressBar.Animate("SetProgress", arg =>
                {
                    progressBar.Progress = arg;
                    var three = 1.0 / 3.0;
                    var two = 1.0 / 1.5;
                    progressBar.ProgressColor = arg < three
                        ? Color.Green
                        : arg < two
                            ? Color.Orange
                            : Color.Red;

                }, 8 * 60, levelType.LeadTime * 1000, Easing.Linear,
                GetStack);
        }

        private void GetStack(double d, bool isAbort)
        {
            if (isAbort)
            {
                return;
            }

            GetStackLayout();
        }

        private Grid GetGrid()
        {
            example = levelType.CreateExample();

            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(2, GridUnitType.Auto)},
                    new RowDefinition {Height = new GridLength(2, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Auto)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                },
                BackgroundColor = Color.FromRgb(232, 232, 240)
            };

            question = new Label
            {
                Text = $"{example.Question}",
                FontSize = 34
            };

            answer = new Label {FontSize = 34};


            var stackLayout = new StackLayout
            {
                Children = {question, answer},
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal
            };

            progressBar = new ProgressBar {Progress = 0};

            var button1 = new Button
            {
                Text = "1",
                FontSize = 34,
                BackgroundColor = color,
                Margin = new Thickness(5, 0, 0, 0)
            };
            var button2 = new Button
            {
                Text = "2",
                BackgroundColor = color,
                FontSize = 34
            };

            var button3 = new Button
            {
                Text = "3",
                FontSize = 34,
                BackgroundColor = color,
                Margin = new Thickness(0, 0, 5, 0)
            };
            var button4 = new Button
            {
                Text = "4",
                FontSize = 34,
                BackgroundColor = color,
                Margin = new Thickness(5, 0, 0, 0)
            };
            var button5 = new Button
            {
                Text = "5",
                BackgroundColor = color,
                FontSize = 34
            };

            var button6 = new Button
            {
                Text = "6",
                FontSize = 34,
                BackgroundColor = color,
                Margin = new Thickness(0, 0, 5, 0)
            };
            var button7 = new Button
            {
                Text = "7",
                FontSize = 34,
                BackgroundColor = color,
                Margin = new Thickness(5, 0, 0, 0)
            };
            var button8 = new Button
            {
                Text = "8",
                BackgroundColor = color,
                FontSize = 34
            };

            var button9 = new Button
            {
                Text = "9",
                FontSize = 34,
                BackgroundColor = color,
                Margin = new Thickness(0, 0, 5, 0)
            };

            var button0 = new Button
            {
                Text = "0",
                FontSize = 34,
                BackgroundColor = color,
                Margin = new Thickness(5, 0, 0, 5)
            };

            var buttonClear = new Button
            {
                Text = "←",
                FontSize = 44,
                BackgroundColor = color,
                Margin = new Thickness(0, 0, 5, 5)
            };

            button1.Clicked += AnswerClicked;
            button2.Clicked += AnswerClicked;
            button3.Clicked += AnswerClicked;
            button4.Clicked += AnswerClicked;
            button5.Clicked += AnswerClicked;
            button6.Clicked += AnswerClicked;
            button7.Clicked += AnswerClicked;
            button8.Clicked += AnswerClicked;
            button9.Clicked += AnswerClicked;
            button0.Clicked += AnswerClicked;
            buttonClear.Clicked += ButtonClearOnClicked;

            grid.Children.Add(stackLayout, 0, 1);
            Grid.SetColumnSpan(stackLayout, 3);
            grid.Children.Add(progressBar, 0, 2);
            Grid.SetColumnSpan(progressBar, 3);

            grid.Children.Add(button7, 0, 3);
            grid.Children.Add(button8, 1, 3);
            grid.Children.Add(button9, 2, 3);

            grid.Children.Add(button4, 0, 4);
            grid.Children.Add(button5, 1, 4);
            grid.Children.Add(button6, 2, 4);

            grid.Children.Add(button1, 0, 5);
            grid.Children.Add(button2, 1, 5);
            grid.Children.Add(button3, 2, 5);

            grid.Children.Add(button0, 0, 6);
            grid.Children.Add(buttonClear, 1, 6);
            Grid.SetColumnSpan(buttonClear, 2);

            return grid;
        }

        private void ButtonClearOnClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(answer.Text))
            {
                answer.Text = answer.Text.Remove(answer.Text.Length - 1);
            }
        }

        private void AnswerClicked(object sender, EventArgs e)
        {
            var button = (Button) sender;

            answer.Text += button.Text;

            if (answer.Text == example.Answer)
            {
                step++;

                if (step == 5 && levelId < 48)
                {
                    levelId++;
                    step = 0;
                    levelType = LevelType.Get(levelId);
                }

                example = levelType.CreateExample();
                question.Text = example.Question;
                answer.Text = string.Empty;
                progressBar.AbortAnimation("SetProgress");
                StartAnimate();
            }
        }

        private void GetStackLayout()
        {
            var frame = GetAnswerCard();

            var button = new Button
            {
                Text = AppResources.Repeat,
                BackgroundColor = color,
                Margin = new Thickness(0, 16, 0, 0),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 130
            };
            button.Clicked += ButtonOnClicked;

            var goBackButton = new Button
            {
                Text = AppResources.Back,
                BackgroundColor = color,
                Margin = new Thickness(0, 16, 0, 0),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 130
            };
            goBackButton.Clicked += GoBackButtonOnClicked;

            //var adMod = new NativeAdView();

            var stack = new StackLayout
            {
                Children = {frame, button, goBackButton },
                BackgroundColor = Color.FromRgb(232, 232, 240)
            };

            Content = stack;
            DependencyService.Get<IAdInterstitial>().ShowAd();
        }

        private Frame GetAnswerCard()
        {
            var frame = new Frame {CornerRadius = 5, Padding = 8, BorderColor = color, Margin = new Thickness(10)};
            var messageStack = new StackLayout();


            if (!example.AnswerMessage.HasMessage)
            {
                var solution = new Label
                {
                    Text = example.AnswerMessage.Solution + example.Answer,
                    TextColor = Color.FromHex("#757575"),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                };
                frame.Content = solution;
            }
            else
            {
                var message = new Label
                {
                    Text = example.AnswerMessage.Message,
                    TextColor = Color.FromHex("#767676"),
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
                    Text = example.AnswerMessage.Solution + example.Answer,
                    TextColor = Color.FromHex("#757575"),
                    FontAttributes = FontAttributes.Bold,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                };

                messageStack.Children.Add(message);
                messageStack.Children.Add(line);
                messageStack.Children.Add(solution);

                frame.Content = messageStack;
            }

            return frame;
        }

        private void GoBackButtonOnClicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopModalAsync();
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}