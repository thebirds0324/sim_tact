using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CartProject.Data;
using System.IO;

namespace CartProject
{
    public partial class App : Application
    {
        static ItemDatabase database_Item;
        static AdsDatabase database_Ads;

        public static ItemDatabase Database_Item
        {
            get
            {
                if (database_Item == null)
                {
                    database_Item = new ItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Items.db3"));
                }
                return database_Item;
            }
        }
        public static AdsDatabase Database_Ads
        {
            get
            {
                if (database_Ads == null)
                {
                    database_Ads = new AdsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdsS.db3"));
                }
                return database_Ads;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
