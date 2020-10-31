using System;
using ThinkFast.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Minus : ContentPage
    {
        public Minus()
        {
            InitializeComponent();
        }

        private async void ThreeThreeClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(3, 3, Operation.Minus);
        }

        private async void TwoOneClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 1, Operation.Minus);
        }

        private async void TwoTwoClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 2, Operation.Minus);
        }
    }
}