using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string title;
        private string body;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(body);
        }

        public new string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Body
        {
            get => body;
            set => SetProperty(ref body, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var userId = Convert.ToInt32(App.Current.Properties[ApplicationKeys.UserId].ToString());
            var newItem = new Message()
            {
                Title = Title,
                Body = body,
                CreatedById = userId,
                CreatedTime = DateTime.UtcNow,
            };

           var result = await this.messageService.CreateMessageAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
