using CartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CartProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
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