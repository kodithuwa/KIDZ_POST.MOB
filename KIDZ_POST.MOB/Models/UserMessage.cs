using System;

namespace KIDZ_POST.MOB.Models
{
    public class UserMessage
    {
        public int UserMessageId { get; set; }

        public int UserId { get; set; }

        public string UserFullName { get; set; }

        public int MessageId { get; set; }

        public DateTime ViewedTime { get; set; }

        public bool IsActivated { get; set; }

    }
}