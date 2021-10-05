
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

    public class MessagesViewModel : BaseViewModel
    {
        private Message _selectedMessage;

        public ObservableCollection<Message> Messages { get; }
        public Command LoadMessagesCommand { get; }
        public Command AddMessageCommand { get; }
        public Command<Message> MessageTapped { get; }

        public MessagesViewModel()
        {
            Title = "Message Store";
            Messages = new ObservableCollection<Message>();
            LoadMessagesCommand = new Command(async () => await ExecuteLoadMessagesCommand());
            AddMessageCommand = new Command(OnAddMessage);
            MessageTapped = new Command<Message>(OnMessageSelected);
        }

        async Task ExecuteLoadMessagesCommand()
        {
            IsBusy = true;
            try
            {
                Messages.Clear();
                var userid = Convert.ToInt32(App.Current.Properties[ApplicationKeys.TeacherId].ToString());
                var items = await messageService.GetAsync(userid);
                foreach (var x in items)
                {
                    Messages.Add(x);
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
            SelectedMessage = null;
        }

        public Message SelectedMessage
        {
            get => _selectedMessage;
            set
            {
                SetProperty(ref _selectedMessage, value);
                OnMessageSelected(value);
            }
        }

        private async void OnAddMessage(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewMessagePage));
        }

        async void OnMessageSelected(Message item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MessageDetailPage)}?{nameof(MessageDetailViewModel.MessageId)}={item.Id.ToString()}");
        }
    }
}