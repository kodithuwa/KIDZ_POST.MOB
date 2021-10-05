using KIDZ_POST.MOB.Models;
using KIDZ_POST.MOB.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIDZ_POST.MOB.Views
{
    public partial class NewMessagePage : ContentPage
    {
        public Message Message { get; set; }

        public NewMessagePage()
        {
            InitializeComponent();
            BindingContext = new NewMessageViewModel();
        }
    }
}