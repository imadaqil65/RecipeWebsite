using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Algorithm
{
    public class RecommendationStrategy
    {
        private readonly IRecipeRepository recipe;
        private readonly IRecommendationStrategy recommendationStrategy;

        public RecommendationStrategy(IRecipeRepository recipe, IRecommendationStrategy recommendationStrategy)
        {
            this.recipe = recipe;
            this.recommendationStrategy = recommendationStrategy;
        }

        public List<Recipe> RecommendRecipes(int? userId)
        {
            try
            {
                return recommendationStrategy.Recommend(recipe, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
