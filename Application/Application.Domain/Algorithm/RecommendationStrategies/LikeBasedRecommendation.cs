using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;

namespace MyApplication.Domain.Algorithm.RecommendationStrategies
{
    public class LikeBasedRecommendation : IRecommendationStrategy
    {
        public List<Recipe> Recommend(IRecipeRepository recipeRepository, int? userId)
        {
            try
            {
                List<Recipe> allRecipes = recipeRepository.ReadActiveItems();
                int recipescount = allRecipes.Count();
                if (allRecipes != null && recipescount>=4)
                {
                    // Order recipes by TotalLikes and then by Name
                    var TopRecipes = allRecipes.OrderByDescending(r => r.TotalLikes).
                        ThenBy(r => r.name).Take(4).ToList();

                    return TopRecipes;
                }
                else if(recipescount>1 && recipescount < 4)
                {
                    // Order recipes by TotalLikes and then by Name
                    var TopRecipes = allRecipes.OrderByDescending(r => r.TotalLikes)
                        .ThenBy(r => r.name).Take(recipescount).ToList();

                    return TopRecipes;
                }
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
