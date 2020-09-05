using CartProject.Models;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public static MessagePort _msgPort;
        private static System.Timers.Timer timer;

        private readonly string TAG = "MessagePortSample";
        int i = 0;

        public ListPage()
        {
            InitializeComponent();

            _msgPort = new MessagePort("sameple_ui_port", false);
            _msgPort.MessageReceived += MessageReceived_Callback;
            _msgPort.Listen();

            timer = new System.Timers.Timer();
            timer.Interval = 3000;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string remoteAppId = "org.example.real_ble";
            string remotePort = "real_ble";

            var msg = new Tizen.Applications.Bundle();
            msg.AddItem("data", "Send_A_MESSAGE_TO_A_REMOTE_APP");

            _msgPort.Send(msg, remoteAppId, remotePort);

        }

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