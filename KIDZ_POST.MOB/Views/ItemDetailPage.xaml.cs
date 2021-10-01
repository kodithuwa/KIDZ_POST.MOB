using KIDZ_POST.MOB.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}