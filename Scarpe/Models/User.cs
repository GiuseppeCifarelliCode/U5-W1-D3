using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scarpe.Models
{
    public class User
    {
        public int Id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role = "user";

        public User() { }
        public User(string name, string surname, string username, string password, string role = "user")
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}