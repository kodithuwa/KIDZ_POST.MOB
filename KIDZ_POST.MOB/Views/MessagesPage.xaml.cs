using KIDZ_POST.MOB.Models;
using KIDZ_POST.MOB.ViewModels;
using KIDZ_POST.MOB.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIDZ_POST.MOB.Views
{
    public partial class MessagesPage : ContentPage
    {
        MessagesViewModel _viewModel;

        public MessagesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MessagesViewModel();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    _viewModel.OnAppearing();
        //}
    }
}