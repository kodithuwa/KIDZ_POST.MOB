using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.ViewModels;
using KIDZ_POST.MOB.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace KIDZ_POST.MOB
{
    public partial class AppShellLow : Xamarin.Forms.Shell
    {
        public AppShellLow()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(MessagesPage), typeof(MessagesPage));
            Routing.RegisterRoute(nameof(MessageDetailPage), typeof(MessageDetailPage));
            Routing.RegisterRoute(nameof(NewMessagePage), typeof(NewMessagePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            MenuItem selectedMenu = (MenuItem)sender;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
