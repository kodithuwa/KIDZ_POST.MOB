using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.ViewModels
{
    public class NewMessageViewModel : BaseViewModel
    {
        private string title;
        private string body;

        public NewMessageViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
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
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var userid = this.AppUserId;
                Message newItem = new Message()
                {
                    Title = Title,
                    Body = Body,
                    CreatedTime = DateTime.UtcNow,
                    CreatedById = userid,
                };


                await messageService.CreateMessageAsync(newItem);
            }
            else
            {
                Message newItem = new Message()
                {
                    Title = Title,
                    Body = Body,
                    CreatedTime = DateTime.UtcNow,
                };
                await messageService.CreateMessageLocalAsync(newItem);
            }

        }
    }
}
