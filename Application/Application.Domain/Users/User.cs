using MyApplication.Domain.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Users
{
    public class User
    {
        public int userId { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }
        public string? firstname { get; private set; }
        public string? middlename { get; private set; }
        public string? lastname { get; private set; }
        public string email { get; private set; }
        public bool isAdmin { get; set; }
        public bool shown { get; set; }


        public User(string username, string password, string email, bool isAdmin, bool shown)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.isAdmin = isAdmin;
            this.shown = shown;
        }

        public User(int userId, string username, string password, string? firstname, string? middlename, string? lastname, string email, bool isAdmin, bool shown)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.email = email;
            this.isAdmin = isAdmin;
            this.shown = shown;
        }

        public User(int userId, string username, string? firstname, string? middlename, string? lastname, string email, bool isAdmin, bool shown)
        {
            this.userId = userId;
            this.username = username;
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.email = email;
            this.isAdmin = isAdmin;
            this.shown = shown;
        }

        public void SetPassword(string password)
        {
            if (String.IsNullOrEmpty(password)) { throw new ArgumentNullException("password"); }
            this.password = password.PasswordHasher();
        }

        public void setUsername(string username) 
        {
            this.username = username; 
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setName(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }
    }
}
