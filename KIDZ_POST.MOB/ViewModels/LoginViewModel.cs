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
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
