using System;
using ThinkFast.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Division : ContentPage
    {
        public Division()
        {
            InitializeComponent();
        }


        private async void TwoOneClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(2, 1, Operation.Division);
        }

        private async void ThreeTwoClicked(object sender, EventArgs e)
        {
            await GameLauncher.Start(3, 1, Operation.Division);
        }
    }
}