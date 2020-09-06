using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CartProject.Models;
using Xamarin.Forms.Internals;
using System.Net.Http;
using System.IO;
using System.Runtime.CompilerServices;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace CartProject.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdsMaker : ContentPage
    {
        public AdsMaker()
        {
            InitializeComponent();
        }

        public static byte[] ConvertImageToByteArray(string filepath)
        {
            byte[] imageByteArray=null;
            FileStream fileStream=new FileStream(filepath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader=new BinaryReader(fileStream))
            {
                imageByteArray=new byte[reader.BaseStream.Length];
                for(int i=0;i<reader.BaseStream.Length;i++)
                    {
                        imageByteArray[i]=reader.ReadByte();
                    }
            }
            return imageByteArray;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var test1 = new Ads();
            var test2 = new Ads();
            test1.Text = new Uri("https://i.imgur.com/aJOvLO6.png");
            test1.Section = 2;
            test2.Text = new Uri("https://i.imgur.com/juoDrb7.png");
            test2.Section = 3;

            await App.Database_Ads.SaveAdsAsync(test1);
            await App.Database_Ads.SaveAdsAsync(test2);

            await Navigation.PopAsync();
        }
    }
}