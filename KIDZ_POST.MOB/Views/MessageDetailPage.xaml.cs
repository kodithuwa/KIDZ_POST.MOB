using KIDZ_POST.MOB.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.Views
{
    public partial class MessageDetailPage : ContentPage
    {
        public MessageDetailPage()
        {
            InitializeComponent();
            BindingContext = new MessageDetailViewModel();
        }
    }
}