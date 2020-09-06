using CartProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Tizen;
using Tizen.Applications.Messages;
using Xamarin.Forms.Xaml;

namespace CartProject.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class ListPageViewModel : INotifyPropertyChanged
    {
        public readonly string TAG = "Message";

        public static MessagePort _msgPort;
        private static System.Timers.Timer timer;
        int sector = 0;
        int i = 0;

        private async void MessageReceived_Callback(object sender, MessageReceivedEventArgs e)
        {
            #region  Log Settings
            /**
            Log.Debug(TAG, "Message Received");
            Log.Debug(TAG, "App ID: " + e.Remote.AppId);
            Log.Debug(TAG, "PortName: " + e.Remote.PortName);
            Log.Debug(TAG, "Trusted: " + e.Remote.Trusted);
            Log.Debug("Message", "message: " + e.Message.GetItem<string>("response data"));
            Log.Debug("Message", "count: " + i);
            i++;
            **/
            #endregion
            string data = e.Message.GetItem<string>("response data");
            sector = Int32.Parse(data);

            List<Ads> adsS = await App.Database_Ads.GetAdsSAsync();
            List<Ads> result = new List<Ads>();

            for (int i = 0; i < adsS.Count; i++)
            {
                if (adsS[i].Section == sector)
                {
                    result.Add(adsS[i]);
                }
            }
            DataList = result;

        }
        private List<Ads> _dataList;

        public List<Ads> DataList
        {
            get { return _dataList; }
            set
            {
                if (value == _dataList)
                {
                    return;
                }
                else
                {
                    _dataList = value;
                    OnPropertyChanged("DataList");
                }
                
            }
        }

        public ListPageViewModel()
        {
            _ = GetAdsData();
            
            _msgPort = new MessagePort("BLE_UI", false);
            _msgPort.MessageReceived += MessageReceived_Callback;
            _msgPort.Listen();


            timer = new System.Timers.Timer();
            timer.Interval = 10000;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            #region Message 통신관련
            
            #endregion

        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string remoteAppId = "org.example.real_ble";
            string remotePort = "real_ble";

            var msg = new Tizen.Applications.Bundle();
            msg.AddItem("data", "Send_A_MESSAGE_TO_A_REMOTE_APP");

            _msgPort.Send(msg, remoteAppId, remotePort);

        }

        #region INotifyPropertyChanged Implement 
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyNmae)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs("DataList"));
            }
        }
        #endregion

        private async Task GetAdsData()
        {

            List<Ads> adsS = await App.Database_Ads.GetAdsSAsync();

            DataList = adsS;
        }
    }
}