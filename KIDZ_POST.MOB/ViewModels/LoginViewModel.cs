using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;

        public Command LoginCommand { get; }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var current = Connectivity.NetworkAccess;
            if(current == NetworkAccess.Internet)
            {
                this.IsInternentAvailable = true;
            }
            else
            {
                this.IsInternentAvailable = false;
            }

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }

            App.Current.Properties.Clear();
            var user = await this.remoteService.LoginAsync(username, password);

            if (user != null && user.IsTeacher)
            {

                App.Current.Properties.Add(ApplicationKeys.UserId, user.Id);
                App.Current.Properties.Add(ApplicationKeys.IsTeacher, true);
                Application.Current.MainPage = new AppShell();

            }
            else
            {
                if (user != null)
                {
                    App.Current.Properties.Add(ApplicationKeys.UserId, user.Id);
                    App.Current.Properties.Add(ApplicationKeys.IsTeacher, false);
                }
                Application.Current.MainPage = new AppShellLow();

            }
        }



    }
}
