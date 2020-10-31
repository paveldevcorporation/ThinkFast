using ThinkFast.Views;
using Xamarin.Forms;

namespace ThinkFast
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute("Training", typeof(Training));
            Routing.RegisterRoute("GamePage", typeof(GamePage));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
