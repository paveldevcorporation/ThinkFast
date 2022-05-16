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

        private async void RuleClicked(object sender, EventArgs e)
        {
            await GameLauncher.RuleMinus();
        }

        private async void ThreeThreeClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(3, 3, Operation.Minus, 25);
        }

        private async void TwoOneClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 1, Operation.Minus, 10);
        }

        private async void TwoTwoClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 2, Operation.Minus, 15);
        }
    }
}