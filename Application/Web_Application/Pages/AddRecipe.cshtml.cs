using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApplication.Domain.Enums;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Services;
using System.Security.Claims;
using Web_Application.DTO;

namespace Web_Application.Pages
{
    [Authorize]
    public class AddRecipeModel : PageModel
    {
        private readonly RecipeServices recipeServices;

        public AddRecipeModel(RecipeServices recipeServices)
        {
            this.recipeServices = recipeServices;
        }
        public string Message { get; set; }
        public string Display { get; set; } = "none";

        [BindProperty] public RecipeDTO recipeDTO { get; set; } = new RecipeDTO();
        [BindProperty] public MainCourseDTO MainCourse { get; set; } = new MainCourseDTO();
        [BindProperty] public DrinkDTO Drink { get; set; } = new DrinkDTO();
        [BindProperty] public DessertDTO Dessert { get; set; } = new DessertDTO();
        [BindProperty] public List<Diet> SelectedDiets { get; set; }

        public void OnGet()
        {
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue("UserID"));
        }

        private void RemoveModelState(string prefix1, string prefix2)
        {
            ModelState.Remove("recipeDTO.image");
            var keys = ModelState.FindKeysWithPrefix(prefix1);
            foreach (var kvp in keys)
            {
                ModelState.Remove(kvp.Key);
            }
            keys = ModelState.FindKeysWithPrefix(prefix2);
            foreach (var kvp in keys)
            {
                ModelState.Remove(kvp.Key);
            }
        }

        private void ReturnError(string msg)
        {
            Display = "block";
            Message = $"An error occured. {msg}";
        }

        public IActionResult OnPostMainCourse()
        {
            try
            {
                RemoveModelState("Dessert", "Drink");
                if (ModelState.IsValid)
                {
                    MainCourse mc = Mapper.setMainCourse(recipeDTO, MainCourse, SelectedDiets, GetUserId());
                    recipeServices.CreateRecipe(mc);
                    return RedirectToPage("Recipes");
                }
                ReturnError(string.Empty);
                return Page();
            }
            catch (Exception ex)
            {
                ReturnError(ex.Message);
                return Page();
            }
        }

        public IActionResult OnPostDrink()
        {
            try
            {
                RemoveModelState("MainCourse", "Dessert");
                if (ModelState.IsValid)
                {
                    Drink dr = Mapper.setDrink(recipeDTO, Drink, GetUserId());
                    recipeServices.CreateRecipe(dr);
                    return RedirectToPage("Recipes");
                }
                ReturnError(string.Empty);
                return Page();
            }
            catch (Exception ex)
            {
                ReturnError(ex.Message);
                return Page();
            }
        }

        public IActionResult OnPostDessert()
        {
            try
            {
                RemoveModelState("Drink", "MainCourse");
                if (ModelState.IsValid)
                {
                    Dessert ds = Mapper.setDessert(recipeDTO, Dessert, GetUserId());
                    recipeServices.CreateRecipe(ds);
                    return RedirectToPage("Recipes");
                }
                ReturnError(string.Empty);
                return Page();
            }
            catch (Exception ex)
            {
                ReturnError(ex.Message);
                return Page();
            }
        }
    }
}
