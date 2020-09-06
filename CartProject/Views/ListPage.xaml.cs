using CartProject.Models;
using CartProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen;
using Tizen.Applications.Messages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CartProject.Views
{
    public partial class ListPage : ContentPage
    {
        private readonly string TAG = "Message";
        public ListPage()
        {
            Log.Debug(TAG, "1");
            InitializeComponent();
        }

        
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
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
        async void OnAdsAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdsMaker
            {
                BindingContext = new Ads()
            });
        }
    }
}