using MyApplication.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Interfaces
{
    public interface IRecipeRepository : IReadRepository<Recipe>, ICreateUpdateDelete<Recipe>
    {
        List<Recipe> GetActiveRecipesPerType(int id);
        List<Recipe> ReadUserRecipes(int id);
        List<Recipe> ReadUserFavorites(int user);
        List<Recipe> GetSimilarRecipes(string query);
    }
}
