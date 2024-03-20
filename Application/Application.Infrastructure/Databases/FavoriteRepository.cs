using Microsoft.Data.SqlClient;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Users;
using MyApplication.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Infrastructure.Databases
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private string query;

        public void CreateFavorite(int user, int recipe)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "INSERT INTO [dbo].[favorite] ([UserId] ,[recipeId]) VALUES (@userid,@recipeid)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("userid", user);
                    command.Parameters.AddWithValue("recipeid", recipe);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Userfavorited(int user, int recipe)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT COUNT(*) FROM favorite WHERE UserId=@userid AND recipeId=@recipeid";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("userid", user);
                    command.Parameters.AddWithValue("recipeid", recipe);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }


        public void DeleteFavorite(int user, int recipe)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "DELETE FROM favorite WHERE UserId=@userid AND recipeId=@recipeid";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("userid", user);
                    command.Parameters.AddWithValue("recipeid", recipe);
                    command.ExecuteNonQuery();
                }
            }
        }


        public int TotalLikes(int recipeId)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT COUNT(*) FROM favorite WHERE recipeId=@recipeid";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("recipeid", recipeId);
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       if(reader.Read())
                        return reader.GetInt32(0);
                       return 0;
                    }
                }
            }
        }
    }
}
