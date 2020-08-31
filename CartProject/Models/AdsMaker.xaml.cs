using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CartProject.Models;

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
            var ads = (Ads)BindingContext;
            ads.Section = 1;

            await App.Database_Ads.SaveAdsAsync(ads);
            await Navigation.PopAsync();
        }
    }
}