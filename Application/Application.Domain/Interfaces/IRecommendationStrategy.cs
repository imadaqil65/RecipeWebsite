using MyApplication.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Interfaces
{
	public interface IRecommendationStrategy
	{
        List<Recipe> Recommend(IRecipeRepository recipeRepository, int? userId);
    }
}
