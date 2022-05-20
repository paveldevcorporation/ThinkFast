using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkFast.Models;
using ThinkFast.Resources;
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

            var countRepeat = App.Database.ExampleRepeat.Count();

            if (countRepeat >= 10)
            {
                Repeat.IsVisible = true;
            }
        }

        private void RepeatButtonOnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void StartGame(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"GamePage");
        }
    }
}