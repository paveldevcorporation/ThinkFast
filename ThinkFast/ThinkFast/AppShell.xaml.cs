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
            //var pref = DependencyService.Get<IPref>();

            //if (true)
            //{
            //    DisplayAlert("THinkFast", "Привет, умнейший из умнейших, гуру счета, смекалки и сообразительности! Сейчас тебе предстоит проверить свои знания, погрузиться в необъятные просторы цифр, проявить свою смекалку и находчивость!", "Ok");
            //    //pref.SavePref();
            //}
            
        }
    }
}