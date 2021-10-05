using KIDZ_POST.MOB.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.Views
{
    public partial class ParentDetailPage : ContentPage
    {
        public ParentDetailPage()
        {
            InitializeComponent();
            BindingContext = new ParentDetailViewModel();
        }
    }
}