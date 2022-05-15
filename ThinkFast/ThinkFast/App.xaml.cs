using ThinkFast.Views;
using ThinkFast.Views.Rules;
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
            Routing.RegisterRoute("AddRule", typeof(AddRule));
            Routing.RegisterRoute("MinusRule", typeof(MinusRule));
            Routing.RegisterRoute("MultiplyRule", typeof(MultiplyRule));
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
