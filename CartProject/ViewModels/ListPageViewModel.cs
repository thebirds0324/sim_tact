
using CartProject.Services;
using CartProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace CartProject.ViewModels
{
    public class ListPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Ads> _dataList;
        public List<Ads> DataList
        {
            get { return _dataList; }
            set
            {
                _dataList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DataList"));
            }
        }

        public ListPageViewModel()
        {
            _ = GetAdsData();
        }

        private async Task GetAdsData()
        {
            List<Ads> adsS = await App.Database_Ads.GetAdsSAsync();

            DataList = adsS;
        }
    }
}