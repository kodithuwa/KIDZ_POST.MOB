using System;

namespace KIDZ_POST.MOB.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsTeacher { get; set; }

        public bool IsActivated { get; set; }
    }
}