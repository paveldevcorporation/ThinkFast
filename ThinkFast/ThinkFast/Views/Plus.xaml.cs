using System;
using ThinkFast.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Plus : ContentPage
    {
        public Plus()
        {
            InitializeComponent();
        }

        private async void RuleClicked(object sender, EventArgs e)
        {
            await GameLauncher.RuleAdd();
        }

        private async void OneOneClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(1, 1, Operation.Plus, 10);
        }

        private async void TwoOneClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 1, Operation.Plus, 10);
        }

        private async void TwoTwoClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 2, Operation.Plus, 15);
        }

        private async void ThreeThreeClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(3, 3, Operation.Plus, 25);
        }
    }
}