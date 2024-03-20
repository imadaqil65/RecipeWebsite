using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Algorithm.RecommendationStrategies
{
    public class IngredientsBasedRecommendation : IRecommendationStrategy
    {
        private readonly Random rnd = new Random();
        public List<Recipe> Recommend(IRecipeRepository recipeRepository, int? userId)
        {
            List<Recipe> favRecipes = recipeRepository.ReadUserFavorites((int)userId);
            List<Recipe> userMade = recipeRepository.ReadUserRecipes((int)userId);
            List<Recipe> finalRecommendation = new List<Recipe>();

            if (recipeRepository.ReadActiveItems() != null && favRecipes.Count()>0)
            {
                foreach (var r in favRecipes)
                {
                    IEnumerable<string> ingredients = r.Ingredients.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x));
                    foreach (string ingredient in ingredients)
                    {
                        List<Recipe> similarRecipes = recipeRepository.GetSimilarRecipes(ingredient);

                        foreach (Recipe sr in similarRecipes)
                        {
                            var notFavorite = favRecipes.Where(x => x.name == sr.name).ToList();
                            var notUserMade = userMade.Where(x => x.name == sr.name).ToList();
                            if (notFavorite.Count() == 0 && notUserMade.Count() == 0)
                            {
                                finalRecommendation.Add(sr);
                            }
                        }
                        similarRecipes.Clear();
                    }
                }
                var uniqueList = finalRecommendation.Distinct().ToList();

                if (uniqueList.Count() > 4)
                {
                    uniqueList.OrderBy(x => rnd.Next()).Take(4);
                }

                return uniqueList;
            }
            else if(favRecipes.Count() == 0)
            {
                return finalRecommendation;
            }
            throw new ArgumentNullException();
        }
    }
}
