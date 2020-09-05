using System;
using Xamarin.Forms;
using Tizen.Applications.Messages;
using Tizen;


namespace CartProject.Tizen
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {

        protected override void OnCreate()
        {
            base.OnCreate();

            LoadApplication(new CartProject.App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app);
            app.Run(args);
        }
    }
}
