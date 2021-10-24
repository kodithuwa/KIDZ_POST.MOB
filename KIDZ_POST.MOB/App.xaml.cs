using KIDZ_POST.Data;
using KIDZ_POST.MOB.Services;
using KIDZ_POST.MOB.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIDZ_POST.MOB
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var db = new KidsPostDatabase("");
            //MainPage = new AppShell();
            MainPage = new LoginPage();
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
