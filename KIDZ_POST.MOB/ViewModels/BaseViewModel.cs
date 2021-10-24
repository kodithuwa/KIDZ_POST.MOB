using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.Models;
using KIDZ_POST.MOB.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        protected readonly IRemoteService remoteService;
        protected readonly IMessageService messageService;

        public BaseViewModel()
        {
            remoteService = new RemoteService();
            messageService = new MessageService();
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public int AppUserId
        {
            get
            {
                var userId = Convert.ToInt32(App.Current.Properties[ApplicationKeys.UserId].ToString());
                return userId;
            }
        }

        public bool AppIsTeacher
        {
            get
            {
                var isTeacher = Convert.ToBoolean(App.Current.Properties[ApplicationKeys.IsTeacher].ToString());
                return isTeacher;
            }
        }

        public bool IsInternentAvailable { get; set; }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
