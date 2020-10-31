using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkFast.Models;
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

        private async void StartGame(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"GamePage");
        }
    }
}