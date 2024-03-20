using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Recipes
{
    public class Comment
    {
        public int Id { get; private set; }
        public int recipeId { get; private set; }
        public int userId { get; private set; }
        public string name { get; private set; }
        public string userComment { get; private set; }

        public Comment(int Id, int recipeId, int userId, string name, string userComment)
        {
            this.Id = Id;
            this.recipeId = recipeId;
            this.userId = userId;
            this.name = name;
            this.userComment = userComment;
        }
        public Comment(int recipeId, int userId, string userComment)
        {
            this.recipeId = recipeId;
            this.userId = userId;
            this.userComment = userComment;
        }
    }
}
