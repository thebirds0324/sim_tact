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
                byte[] bmp = null;

                Image image=Image.Fromfile(filepath);

                var ms=new MemoryStream();
                image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);

                var bytes=ms.ToArray();
                ads.Image = bytes;

                
                await App.Database_Ads.SaveAdsAsync(ads);
            }
            await Navigation.PopAsync();
        }


    }
}