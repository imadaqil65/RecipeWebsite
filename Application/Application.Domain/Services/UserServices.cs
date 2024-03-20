using MyApplication.Domain.Algorithm;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Services
{
    public class UserServices
    {
        private readonly IUserRepository datasource;
        public UserServices(IUserRepository datasource)
        {
            this.datasource = datasource;
        }

        public void CreateUser(User u)
        {
            datasource.CreateItem(u);
        }
        public void UpdateUser(User u)
        {
            datasource.UpdateItem(u);
        }
        public void DeleteUser(int id)
        {
            datasource.DeleteItem(id);
        }
        public User GetUserById(int id)
        {
            return datasource.GetItemById(id);
        }
        public User GetUserByName(string username)
        {
            return datasource.GetUserByName(username);  
        }
        public IReadOnlyCollection<User> ReadAllUsers()
        {
            return datasource.ReadAllItems();
        }
        public IReadOnlyCollection<User> ReadActiveUsers()
        {
            return datasource.ReadActiveItems();
        }

        //User Verification

        public bool CheckUsername(string username)
        {
            return datasource.CheckUsername(username);
        }
        public bool CheckEmail(string email)
        {
            return datasource.CheckEmail(email);
        }
        private string GetHash(string username)
        {
            return datasource.GetHashedPasswordByUsername(username);
        }
        public string HashPassword(string password)
        {
            return Hashing.PasswordHasher(password);
        }
        public bool VerifyPassword(string username, string password)
        {
            string hash = GetHash(username);
            if (hash != null)
                return Hashing.VerifyPassword(password, GetHash(username));
            else
                return false;
        }

    }
}
