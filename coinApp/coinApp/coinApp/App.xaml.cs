using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace coinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android={819203c6-5adb-4956-a4f7-5c0a7612c16f};" +
                  "uwp={819203c6-5adb-4956-a4f7-5c0a7612c16f};" +
                  "ios={819203c6-5adb-4956-a4f7-5c0a7612c16f};" +
                  "macos={819203c6-5adb-4956-a4f7-5c0a7612c16f};",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
