using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using MyApplication.Domain.Algorithm;
using MyApplication.Domain.Algorithm.RecommendationStrategies;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using MyApplication.Infrastructure.Databases;
using System.Security.Claims;

namespace Web_Application.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty] public string SearchTerm { get; set; }
        private RecommendationStrategy CurrentStrategy { get; set; }
        public List<Recipe> RecommendedRecipes { get; set; } = null;
        public string Message { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            CurrentStrategy = new RecommendationStrategy(new RecipeRepository(), new LikeBasedRecommendation());
        }

        public void OnGet()
        {
            TryRecommend();
        }

        public void OnPostTopRecipes()
        {
            SetCurrentStrategy(new LikeBasedRecommendation());
            TryRecommend();
        }

        public void OnPostRandomRecipes()
        {
            SetCurrentStrategy(new RandomBasedRecommendation());
            TryRecommend();
        }

        public void OnPostSimilarRecipes()
        {
            SetCurrentStrategy(new IngredientsBasedRecommendation());
            TryRecommend();
        }

        public void OnPost()
        {
            var searchTerm = this.SearchTerm;
            RedirectToPage("/Recipes", new { searchTerm });
        }

        // Recommend Algorithm
        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue("UserID"));
        }
        private void SetCurrentStrategy(IRecommendationStrategy recommendation)
        {
            CurrentStrategy = new RecommendationStrategy(new RecipeRepository(), recommendation);
        }

        private void TryRecommend()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    RecommendedRecipes = CurrentStrategy.RecommendRecipes(null);
                }
                else
                {
                    RecommendedRecipes = CurrentStrategy.RecommendRecipes(GetUserId());
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}