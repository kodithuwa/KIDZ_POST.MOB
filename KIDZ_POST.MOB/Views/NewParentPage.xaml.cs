using KIDZ_POST.MOB.Models;
using KIDZ_POST.MOB.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIDZ_POST.MOB.Views
{
    public partial class NewParentPage : ContentPage
    {
        public new Parent Parent { get; set; }

        public NewParentPage()
        {
            InitializeComponent();
            BindingContext = new NewParentViewModel();
        }
    }
}