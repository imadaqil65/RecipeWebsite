using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApplication.Domain.Algorithm;
using MyApplication.Domain.CustomException;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Services;

namespace Web_Application.Pages
{
    public class recipesModel : PageModel
    {
        private readonly RecipeServices recipeServices;
        public string Message { get; private set; }
        private PaginationHelper<Recipe> paginationRecipe { get; set; }
        public PaginatedList<Recipe> paginatedRecipes { get; set; }
        private IReadOnlyCollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        [BindProperty] public string? searchterm { get; set; }
        [BindProperty] public string recipeType { get; set; }

        public recipesModel(RecipeServices recipeServices)
        {
            this.recipeServices = recipeServices;
        }

        public void OnGet(int pageindex = 1, string? searchterm = null, int recipeType = 0)
        {
            try
            {
                Func<Recipe, bool>? searchFilter = null;
                this.searchterm = searchterm;
                if (recipeType == 0)
                {
                    Recipes = new List<Recipe>(recipeServices.ViewActiveRecipes());
                }
                else
                {
                    Recipes = recipeServices.GetActiveRecipesPerType(recipeType);
                }

                if (!string.IsNullOrEmpty(searchterm))
                {
                    searchFilter = recipes => recipes.name.Contains(searchterm, (StringComparison)5);
                }
                paginationRecipe = new PaginationHelper<Recipe>(Recipes, pageSize: 8);
                paginatedRecipes = paginationRecipe.GetPage(pageindex, searchFilter);
                var visiblePageNumbers = paginationRecipe.GetVisiblePageNumbers(pageindex, paginatedRecipes.TotalPages, maxVisiblePages: 5);
                ViewData["VisiblePageNumbers"] = visiblePageNumbers;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
