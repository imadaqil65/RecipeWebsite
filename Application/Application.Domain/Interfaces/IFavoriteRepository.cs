using MyApplication.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Interfaces
{
    public interface IFavoriteRepository
    {
        void CreateFavorite(int user, int recipe);
        void DeleteFavorite(int user, int recipe);
        bool Userfavorited(int user, int recipe);
    }
}
