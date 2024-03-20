using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Services
{
    public class FeaturesServices
    {
        private readonly ICommentRepository commentRepo;
        private readonly IFavoriteRepository favoriteRepo;
        public FeaturesServices(ICommentRepository commentRepo, IFavoriteRepository favoriteRepo)
        {
            this.commentRepo = commentRepo;
            this.favoriteRepo = favoriteRepo;
        }

        public void CreateComment(Comment c)
        {
            commentRepo.CreateItem(c);
        }

        public void CreateFavorite(int user, int recipe)
        {
            favoriteRepo.CreateFavorite(user, recipe);
        }

        public void DeleteComment(int id)
        {
            commentRepo.DeleteItem(id);
        }

        public void DeleteFavorite(int user, int recipe)
        {
            favoriteRepo.DeleteFavorite(user, recipe);
        }

        public List<Comment> ReadAllComments(int recipe)
        {
            return commentRepo.ReadAllComments(recipe);
        }

        public bool userFavorited(int user, int recipe)
        {
            return favoriteRepo.Userfavorited(user, recipe);
        }
    }
}
