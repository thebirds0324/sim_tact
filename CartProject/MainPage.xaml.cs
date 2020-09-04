using CartProject.Data;
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

            var cell = new DataTemplate(typeof(ImageCell));
            #region cell선언 (주석처리중)
            //var bnd = new Binding("Image", BindingMode.Default, new ByteArrayToImageConverter());
            //cell.SetBinding(ImageCell.ImageSourceProperty,bnd);
            //cell.SetBinding(TextCell.TextProperty, "Text");
            #endregion
            cell.SetBinding(ImageCell.ImageSourceProperty, "Text");


            listView.RowHeight = 150;
            listView.ItemTemplate = cell;
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
