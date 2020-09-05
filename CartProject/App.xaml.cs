using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CartProject.Services;
using System.IO;

namespace CartProject
{
    public partial class App : Application
    {
        static SQLiteService database_Ads;

        public static SQLiteService Database_Ads
        {
            get
            {
                if (database_Ads == null)
                {
                    database_Ads = new SQLiteService();
                }
                return database_Ads;
            }
        }
       
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new CartProject.Views.ListPage());
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
