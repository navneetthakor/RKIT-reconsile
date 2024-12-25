using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        public int UserId { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public User(int userId, string name, string email, string password, string mobileNumber)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            MobileNumber = mobileNumber;
        }
    }
}