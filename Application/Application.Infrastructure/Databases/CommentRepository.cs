using Microsoft.Data.SqlClient;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using MyApplication.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Infrastructure.Databases
{
    public class CommentRepository : ICommentRepository
    {
        private string query;
        public void CreateItem(Comment c)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "INSERT INTO [dbo].[comment] ([userId],[recipeId],[comment],[Active]) VALUES (@userid,@recipeid,@comment,1)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("userid",c.userId);
                    command.Parameters.AddWithValue("recipeid", c.recipeId);
                    command.Parameters.AddWithValue("comment", c.userComment);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteItem(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "UPDATE comment SET Active=0 WHERE CommentId = @commentId";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("commentId", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Comment> ReadAllComments(int recipe)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT c.*, u.username FROM comment c INNER JOIN [user] u ON u.userID = c.userId WHERE c.recipeId = @recipeid AND c.Active = 1";
                List<Comment> Comments = new List<Comment>();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("recipeid", recipe);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Comments.Add(reader.MapToComment());
                        }
                        return Comments;
                    }
                }
            }
        }

        public void UpdateItem(Comment c)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "UPDATE comment SET userId = @userid, recipeId = @recipeid, comment = @comment WHERE CommentId = @commentId";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("CommentId", c.Id);
                    command.Parameters.AddWithValue("userid", c.userId);
                    command.Parameters.AddWithValue("recipeid", c.recipeId);
                    command.Parameters.AddWithValue("comment", c.userComment);
                    command.ExecuteNonQuery();
                }
            }
        }

/*        public int TotalComments(int recipeId)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SElECT COUNT comment FROM comment WHERE recipeId = @recipeId AND Active = 1";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("recipeid", recipeId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) 
                    {
                        return reader.GetInt32(0);
                    }
                    return default;
                }
            }
        }*/
    }
}
