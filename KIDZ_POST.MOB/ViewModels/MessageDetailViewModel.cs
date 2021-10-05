using KIDZ_POST.MOB.Common;
using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.ViewModels
{
    [QueryProperty(nameof(MessageId), nameof(MessageId))]
    public class MessageDetailViewModel : BaseViewModel
    {
        private string messageId;
        private string title;
        private string body;
        public int Id { get; set; }

        public ObservableCollection<UserMessage> UserMessages { get; }

        public MessageDetailViewModel()
        {
            UserMessages = new ObservableCollection<UserMessage>();
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

        public string MessageId
        {
            get
            {
                return messageId;
            }
            set
            {
                messageId = value;
                LoadMessageId(value);
            }
        }

        public async void LoadMessageId(string messageId)
        {
            try
            {
                var msgId = Convert.ToInt32(messageId);
                var item = await this.messageService.GetMessageAsync(msgId);
                await Task.Delay(1000);
                var teacherId = Convert.ToInt32(App.Current.Properties[ApplicationKeys.TeacherId].ToString());
                var userMessages = await this.messageService.GetUserMessages(msgId, teacherId);
                UserMessages.Clear();
                if(userMessages != null )
                foreach (var x in userMessages)
                {
                    UserMessages.Add(x);
                }

                Id = item.Id;
                Title = item.Title;
                Body = item.Body;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
