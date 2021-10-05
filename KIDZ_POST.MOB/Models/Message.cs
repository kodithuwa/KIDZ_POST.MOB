using System;

namespace KIDZ_POST.MOB.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int CreatedById { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}