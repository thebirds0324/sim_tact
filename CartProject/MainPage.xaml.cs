using CartProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CartProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database_Ads.GetAdsSAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new SearchPage
                {
                    BindingContext = e.SelectedItem as Ads
                });
            }
        }

        // 버튼 Event
        async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage { });
        }
        async void OnCalcButtonClicked(object sender, EventArgs e)
        {
            
        }
        async void OnAdsAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdsMaker
            {
                BindingContext = new Ads()
            });
        }
    }


}
