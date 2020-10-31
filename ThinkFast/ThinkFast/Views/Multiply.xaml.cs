using System;
using ThinkFast.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Multiply : ContentPage
    {
        public Multiply()
        {
            InitializeComponent();
        }

        private async void OneOneClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(1, 1, Operation.Multiply);
        }

        private async void TwoOneClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 1, Operation.Multiply);
        }

        private async void TwoTwoClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 2, Operation.Multiply);
        }
        private async void ThreeThreeClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(3, 3, Operation.Multiply);
        }
    }
}