using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using RecruitmentSystem.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecruitmentSystem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage())
            {

                BarBackgroundColor = Color.FromHex("#1e549f")
            };
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
