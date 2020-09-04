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
                for(int i=0;i&lt;reader.BaseStream.Length;i++)
                    {
                        imageByteArray[i]=reader.ReadByte();
                    }
            }
            return imageByteArray;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            for(int i=0; i<3; i++)
            {
                Random random = new Random();
                var ads = new Ads();

                // Initialize 하기
                ads.Section = random.Next(0, 2);
                ads.Text = "Test Text #" + i;

                string filePath = "local:EmbeddedImage ResourceId=CartProject.Data.Images_Ads.ads_1_test.png";
                byte[] result=ConvertImageToByteArray(filepath);

                
                await App.Database_Ads.SaveAdsAsync(ads);
            }
            await Navigation.PopAsync();
        }


    }
}