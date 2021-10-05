using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.Views;
using System;
using System.Collections.Generic;
using System.Text;
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
                App.Current.Properties.Add(ApplicationKeys.UserId, user.Id);
                App.Current.Properties.Add(ApplicationKeys.IsTeacher, false);
                Application.Current.MainPage = new AppShellLow();

            }
        }
    }
}
