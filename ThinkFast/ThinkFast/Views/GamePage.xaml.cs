using System;
using System.Linq;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
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
        private double points = 0;


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

            var pointResult = new Result(points);
            App.Database.Result.SaveItem(pointResult);

            var exampleRepeat = new ExampleRepeat(example.First, example.Second, example.LevelType.Operation.Id);
            App.Database.ExampleRepeat.SaveItem(exampleRepeat);

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
                points += (1 - progressBar.Progress) * 10 * levelType.PointCoefficient;
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
            ChartEntry GetChartEntry(Result x)
            {
                return new ChartEntry((float)x.Points)
                {
                    Label = x.Date.ToShortDateString(),
                    ValueLabel = x.Points.ToString("F0"),
                    Color =  SKColor.Parse("#006C84")
                };
            }

            var currentFrame = new Frame
            {
                WidthRequest = 50,
                CornerRadius = 10
            };
            var label = new Label
            {
                Text = AppResources.Score,
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var text = new Label
            {
                Text = points.ToString("F0"),
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center
            }; 

            

            var currentStack = new StackLayout();
            currentStack.Children.Add(label);
            currentStack.Children.Add(text);
            currentFrame.Content = currentStack;


            var record = App.Database.Result.Max(x => x.Points);

            var recordFrame = new Frame
            {
                WidthRequest = 50,
                CornerRadius = 10
            };
            var recordLabel = new Label
            {
                Text = AppResources.Record,
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var recordText = new Label
            {
                Text = record.ToString("F0"),
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center
            };



            var recordStack = new StackLayout();
            recordStack.Children.Add(recordLabel);
            recordStack.Children.Add(recordText);
            recordFrame.Content = recordStack;

            var frameStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            frameStack.Children.Add(currentFrame);
            frameStack.Children.Add(recordFrame);

            var results = App.Database.Result.Get(null, 15);
            var entries = results.OrderBy(x => x.Id).Select(GetChartEntry);
            var chart = new ChartView
            {
                HeightRequest = 250,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Chart = new LineChart
                {
                    Entries = entries,
                    LineMode = LineMode.Spline,
                    PointMode = PointMode.Circle,
                    BackgroundColor = SKColor.Parse("#fafafa"),
                    IsAnimated = true,
                    LabelOrientation = Orientation.Vertical,
                    ValueLabelOrientation = Orientation.Horizontal,
                    LabelTextSize = (float)Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                }
            };

            var goBackButton = new Button
            {
                Text = AppResources.Back,
                BackgroundColor = color,
                CornerRadius = 20,
                Margin = new Thickness(0, 16, 0, 16),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 130
            };
            goBackButton.Clicked += GoBackButtonOnClicked;

            var stack = new StackLayout
            {
                Children = { frameStack, chart, goBackButton },
                BackgroundColor = Color.FromHex("#fafafa")
            };

            Content = stack;
        }

        private void GoBackButtonOnClicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopModalAsync();
            DependencyService.Get<IAdInterstitial>().ShowAd();
        }
    }
}