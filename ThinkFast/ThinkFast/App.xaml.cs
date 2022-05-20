using System;
using System.IO;
using ThinkFast.Repositories;
using ThinkFast.Views;
using ThinkFast.Views.Rules;
using Xamarin.Forms;

namespace ThinkFast
{
    public partial class App : Application
    {
        private const string DATABASE_NAME = "game.db";
        private static Repository database;
        public static Repository Database =>
            database ?? (database = new Repository(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)));

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute("Training", typeof(Training));
            Routing.RegisterRoute("GamePage", typeof(GamePage));
            Routing.RegisterRoute("AddRule", typeof(AddRule));
            Routing.RegisterRoute("MinusRule", typeof(MinusRule));
            Routing.RegisterRoute("MultiplyRule", typeof(MultiplyRule));
            Routing.RegisterRoute("DivisionRule", typeof(DivisionRule));
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
