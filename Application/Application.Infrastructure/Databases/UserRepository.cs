using Microsoft.Data.SqlClient;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Users;
using MyApplication.Infrastructure.Mapping;
using System.Text.RegularExpressions;

namespace MyApplication.Infrastructure.Databases
{
    public class UserRepository : IUserRepository
    {
        private string query;
        public bool CheckUsername(string username)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = SqlResource.CheckUsername;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // If count is greater than 0, the user exists; otherwise, they don't.
                }
            }
        }
        public bool CheckEmail(string email)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = SqlResource.CheckEmail;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@email", email);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // If count is greater than 0, the user exists; otherwise, they don't.
                }
            }
        }

        public string GetHashedPasswordByUsername(string username)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = SqlResource.GetHashedPasswordByUsername;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
                return null;
            }
        }

        public void CreateItem(User u)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    query = SqlResource.InsertUser;
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@username", u.username);
                        command.Parameters.AddWithValue("@password", u.password);
                        command.Parameters.AddWithValue("@firstname", u.firstname ?? string.Empty);
                        command.Parameters.AddWithValue("@middlename", u.middlename ?? string.Empty);
                        command.Parameters.AddWithValue("@lastname", u.lastname ?? string.Empty);
                        command.Parameters.AddWithValue("@email", u.email);
                        command.Parameters.AddWithValue("@admin", u.isAdmin);
                        command.ExecuteNonQuery();
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItem(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = SqlResource.DeleteUser;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                query = "UPDATE recipe SET shown = 0 WHERE FK_authorid = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            };
        }

        public User GetItemById(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = SqlResource.GetUserById;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.MapToUser();
                    };
                }
                return null;
            };
        }

        private bool isEmail(string email)
        {
            Regex EmailValidation = new Regex("^\\S+@\\S+\\.\\S+$");
            return EmailValidation.IsMatch(email);
        }

        public User GetUserByName(string username)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                if(isEmail(username))
                    query = SqlResource.GetUserByEmail;
                else
                    query = SqlResource.GetUserByName;

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.MapToUser();
                    };
                }
                return null;
            };
        }

        public List<User> ReadAllItems()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                List<User> userlist = new List<User>();
                query = SqlResource.ViewAllUsers;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userlist.Add(reader.MapToUserNoPasword());
                    };
                    return userlist;
                }
            };
        }

        public List<User> ReadActiveItems()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                List<User> userlist = new List<User>();
                query = SqlResource.ViewActiveUsers;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userlist.Add(reader.MapToUserNoPasword());
                    };
                    return userlist;
                }
            }
        }

        public void UpdateItem(User u)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = SqlResource.UpdateUser;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", u.userId);
                    command.Parameters.AddWithValue("@username", u.username);
                    command.Parameters.AddWithValue("@password", u.password);
                    command.Parameters.AddWithValue("@firstname", u.firstname ?? string.Empty);
                    command.Parameters.AddWithValue("@middlename", u.middlename ?? string.Empty);
                    command.Parameters.AddWithValue("@lastname", u.lastname ?? string.Empty);
                    command.Parameters.AddWithValue("@email", u.email);
                    command.Parameters.AddWithValue("@admin", u.isAdmin);
                    command.Parameters.AddWithValue("@shown", u.shown);
                    command.ExecuteNonQuery();
                }
                query = "UPDATE recipe SET shown = @shown WHERE FK_authorid = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", u.userId);
                    command.Parameters.AddWithValue("@shown", u.shown);
                    command.ExecuteNonQuery();
                }
            };
        }


    }
}
