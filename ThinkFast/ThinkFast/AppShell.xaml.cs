using ThinkFast.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThinkFast
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            var pref = DependencyService.Get<IPref>();

            if (pref.GetPref())
            {
                DisplayAlert("THinkFast", "Привет ребята", "Ok");
            }
            
        }
    }
}