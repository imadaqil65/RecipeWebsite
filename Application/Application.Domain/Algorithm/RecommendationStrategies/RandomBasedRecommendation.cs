using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Algorithm.RecommendationStrategies
{
    public class RandomBasedRecommendation : IRecommendationStrategy
    {
        private readonly Random rnd = new Random();

        public List<Recipe> Recommend(IRecipeRepository recipeRepository, int? userId)
        {
            try
            {
                List<Recipe> recipes = recipeRepository.ReadActiveItems();
                int recipescount = recipes.Count();
                if (recipes != null && recipes.Count>=4)
                {
                    var randomizedRecipes = recipes.OrderBy(x => rnd.Next()).Take(4).ToList();
                    return randomizedRecipes;
                }
                else if(recipescount>1 && recipescount < 4)
                {
                    var randomizedRecipes = recipes.OrderBy(x => rnd.Next()).Take(recipescount).ToList();
                    return randomizedRecipes;
                }
                throw new ArgumentNullException();
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }
    }
}
