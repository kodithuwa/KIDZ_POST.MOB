using KIDZ_POST.MOB.Models;
using KIDZ_POST.MOB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIDZ_POST.MOB.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageUser : ContentView
    {
        private readonly IMessageService messageService; 

        public static readonly BindableProperty IsActivatedProperty = BindableProperty.Create(
                                                                          propertyName: "IsActivate",
                                                                          defaultValue: false,
                                                                          returnType: typeof(bool),
                                                                          declaringType: typeof(MessageUser),
                                                                          defaultBindingMode: BindingMode.TwoWay,
                                                                          propertyChanged: IsActivatedPropertyChanged);
        
        private static void IsActivatedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var messageUserControl = (MessageUser)bindable;
            messageUserControl.IsActivated = (bool)newValue;
        }

        public bool IsActivated
        {
            get { return Convert.ToBoolean(base.GetValue(IsActivatedProperty)); }
            set { base.SetValue(IsActivatedProperty, value); }
        }


        public static readonly BindableProperty UserFullNameProperty = BindableProperty.Create(
                                                                  propertyName: "UserFullName",
                                                                  defaultValue: string.Empty,
                                                                  returnType: typeof(string),
                                                                  declaringType: typeof(MessageUser),
                                                                  defaultBindingMode: BindingMode.TwoWay,
                                                                  propertyChanged: UserFullNamePropertyChanged);

        private static void UserFullNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var messageUserControl = (MessageUser)bindable;
            messageUserControl.UserFullName = (string)newValue;
        }

        public string UserFullName
        {
            get { return base.GetValue(UserFullNameProperty).ToString(); }
            set { base.SetValue(UserFullNameProperty, value); }
        }


        public static readonly BindableProperty UserMessageIdProperty = BindableProperty.Create(
                                                                propertyName: "UserMessageId",
                                                                defaultValue: 0,
                                                                returnType: typeof(int),
                                                                declaringType: typeof(MessageUser),
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: UserMessageIdPropertyChanged);

        private static void UserMessageIdPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var messageUserControl = (MessageUser)bindable;
            messageUserControl.UserMessageId = (int)newValue;
        }

        public int UserMessageId
        {
            get { return (int)base.GetValue(UserMessageIdProperty); }
            set { base.SetValue(UserMessageIdProperty, value); }
        }

        public static readonly BindableProperty UserIdProperty = BindableProperty.Create(
                                                        propertyName: "UserId",
                                                        defaultValue: 0,
                                                        returnType: typeof(int),
                                                        declaringType: typeof(MessageUser),
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: UserIdPropertyChanged);

        private static void UserIdPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var messageUserControl = (MessageUser)bindable;
            messageUserControl.UserId = (int)newValue;
        }

        public int UserId
        {
            get { return (int)base.GetValue(UserIdProperty); }
            set { base.SetValue(UserIdProperty, value); }
        }

        public static readonly BindableProperty MessageIdProperty = BindableProperty.Create(
                                                                propertyName: "MessageId",
                                                                defaultValue: 0,
                                                                returnType: typeof(int),
                                                                declaringType: typeof(MessageUser),
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: MessageIdPropertyChanged);

        private static void MessageIdPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var messageUserControl = (MessageUser)bindable;
            messageUserControl.MessageId = (int)newValue;
        }

        public int MessageId
        {
            get { return (int)base.GetValue(UserMessageIdProperty); }
            set { base.SetValue(UserMessageIdProperty, value); }
        }


        public MessageUser()
        {
            InitializeComponent();
            this.messageService = new MessageService();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var userMessage = new UserMessage
            {
                UserMessageId = this.UserMessageId,
                UserId = this.UserId,
                MessageId = this.MessageId,
                IsActivated = this.IsActivated,
            };

            var isSelected = e.Value;
            var status = isSelected ? this.messageService.CreateUserMessagesAsync(userMessage) 
                : this.messageService.DeleteUserMessageAsync(this.UserMessageId);
        }
    }
}