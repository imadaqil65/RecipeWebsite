using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApplication.Domain.Enums;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Web_Application.Pages
{
    //[Authorize]
    public class RecipeDetailsModel : PageModel
    {
        
        private readonly RecipeServices recipeServices;
        private readonly FeaturesServices featureServices;

        [BindProperty, Required, MinLength(5, ErrorMessage = "Comment must be at least 5 characters long"), MaxLength(700)]
        public string UserComment { get; set; }
        public List<Comment> comments { get; private set; }
        public bool liked { get; private set; } = false;
        //public int TotalFavorite { get; private set; }
        public string ErrorMessage { get; set; } = string.Empty;
        
        
        //Recipe Object
        public Recipe recipe { get; private set; }

        public RecipeDetailsModel(RecipeServices recipeServices, FeaturesServices featureServices)
        {
            this.recipeServices = recipeServices;
            this.featureServices = featureServices;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                recipe = recipeServices.GetRecipeById(id);
                if(recipe != null)
                {
                    //TotalFavorite = featureServices.TotalFavorite(id);
                    comments = featureServices.ReadAllComments(id);
                    if (User.Identity.IsAuthenticated)
                    {
                        liked = featureServices.userFavorited(int.Parse(User.FindFirstValue("UserID")), id);
                    }
                    return Page();
                }
                return Page();
            }
            catch (Exception ex) 
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }

        public IActionResult OnPostLike(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    featureServices.CreateFavorite(int.Parse(User.FindFirstValue("UserID")), id);
                    return RedirectToPage("/RecipeDetails", new { id });
                }
                string ReturnUrl = $"/RecipeDetails?id={id}";
                return RedirectToPage("/Login", new { ReturnUrl });
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }

        public IActionResult OnPostDislike(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    featureServices.DeleteFavorite(int.Parse(User.FindFirstValue("UserID")), id);
                    return RedirectToPage("/RecipeDetails", new { id });
                }
                string ReturnUrl = $"/RecipeDetails?id={id}";
                return RedirectToPage("/Login", new { ReturnUrl });
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }

        public IActionResult OnPostComment(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    Comment cm = new Comment(id, int.Parse(User.FindFirstValue("UserID")), UserComment);
                    featureServices.CreateComment(cm);
                    return RedirectToPage("/RecipeDetails", new { id });
                }
                string ReturnUrl = $"/RecipeDetails?id={id}";
                return RedirectToPage("/Login", new { ReturnUrl });
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }

        public IActionResult OnPostDeleteComment(int id, int recipe)
        {
            try
            {
                featureServices.DeleteComment(id);
                return RedirectToPage("/RecipeDetails", new { recipe });
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }
    }
}
