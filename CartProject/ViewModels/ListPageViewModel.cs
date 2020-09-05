
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
using Tizen.Applications.Messages;
using Tizen;
using Xamarin.Forms.Xaml;

namespace CartProject.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class ListPageViewModel : INotifyPropertyChanged
    {
        public static MessagePort _msgPort;
        private static System.Timers.Timer timer;

        private readonly string TAG = "MessagePortSample";
        int i = 0;

        private void MessageReceived_Callback(object sender, MessageReceivedEventArgs e)
        {
            Log.Debug(TAG, "Message Received");
            Log.Debug(TAG, "App ID: " + e.Remote.AppId);
            Log.Debug(TAG, "PortName: " + e.Remote.PortName);
            Log.Debug(TAG, "Trusted: " + e.Remote.Trusted);
            Log.Debug(TAG, "message: " + e.Message.GetItem<string>("response data"));
            Log.Debug(TAG, "count: " + i);
            i++;
        }
        private List<Ads> _dataList;

        public List<Ads> DataList
        {
            get { return _dataList; }
            set
            {
                if (value == _dataList) return;
                _dataList = value;
                OnPropertyChanged("DataList");
            }
        }

        public ListPageViewModel()
        {
            _ = GetAdsData();

            /**
            #region Message 통신관련
            _msgPort = new MessagePort("sameple_ui_port", false);
            _msgPort.MessageReceived += MessageReceived_Callback;
            _msgPort.Listen();

            timer = new System.Timers.Timer();
            timer.Interval = 3000;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            #endregion
            **/
        }
        private void OnTimedEvent_TESTAsync(Object source, System.Timers.ElapsedEventArgs e)
        {
            _ = GetAdsData();
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