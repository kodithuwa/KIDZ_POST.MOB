
namespace KIDZ_POST.MOB.ViewModels
{
    using KIDZ_POST.MOB.Models;
    using KIDZ_POST.MOB.Views;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using KIDZ_POST.MOB.Common;

    public class ParentsViewModel : BaseViewModel
    {
        private Parent _selectedParent;

        public ObservableCollection<Parent> Parents { get; }
        public Command LoadParentsCommand { get; }
        public Command AddParentCommand { get; }
        public Command<Parent> ParentTapped { get; }

        public ParentsViewModel()
        {
            Title = "Parent Store";
            Parents = new ObservableCollection<Parent>();
            LoadParentsCommand = new Command(async () => await ExecuteLoadParentsCommand());
            AddParentCommand = new Command(OnAddParent);
            ParentTapped = new Command<Parent>(OnParentSelected);
        }

        async Task ExecuteLoadParentsCommand()
        {
            IsBusy = true;
            try
            {
                Parents.Clear();
                var userid = Convert.ToInt32(App.Current.Properties[ApplicationKeys.TeacherId].ToString());
                var items = await remoteService.GetParentsAsync(userid);
                foreach (var x in items)
                {
                    Parents.Add(x);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedParent = null;
        }

        public Parent SelectedParent
        {
            get => _selectedParent;
            set
            {
                SetProperty(ref _selectedParent, value);
                OnParentSelected(value);
            }
        }

        private async void OnAddParent(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewParentPage));
        }

        async void OnParentSelected(Parent item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ParentDetailPage)}?{nameof(ParentDetailViewModel.ParentId)}={item.Id.ToString()}");
        }
    }
}