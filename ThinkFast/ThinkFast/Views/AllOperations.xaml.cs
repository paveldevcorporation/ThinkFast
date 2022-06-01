using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllOperations : ContentPage
    {
        public AllOperations()
        {
            InitializeComponent();
        }

        private async void RepeatButtonOnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"RepeatPage");
        }

        private async void StartGame(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"GamePage");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var countRepeat = App.Database.ExampleRepeat.Count(x => !x.Learned);

            Repeat.IsVisible = countRepeat >= 25;
        }
    }
}