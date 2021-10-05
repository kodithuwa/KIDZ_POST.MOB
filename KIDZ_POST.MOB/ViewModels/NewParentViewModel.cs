using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.ViewModels
{
    public class NewParentViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private string description;
        private int? teacherId;
        private bool isTeacher;
        private bool isActivated;

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public NewParentViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(firstName)
                && !String.IsNullOrWhiteSpace(lastName)
                && !String.IsNullOrWhiteSpace(description);
        }


        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var userid = Convert.ToInt32(App.Current.Properties[ApplicationKeys.TeacherId].ToString());
            Parent newItem = new Parent()
            {
                FirstName = FirstName,
                LastName = LastName,
                Description = Description,
                TeacherId = userid,
                IsActivated = true,
                IsTeacher = false,
            };

            var xx = await remoteService.CreateParentAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
