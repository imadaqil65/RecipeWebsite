using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApplication.Domain.Enums;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Services;
using System.Collections;
using System.Security.Claims;
using Web_Application.DTO;

namespace Web_Application.Pages
{
    [Authorize]
    public class EditDetailsModel : PageModel
    {
        private readonly RecipeServices recipeServices;

        public EditDetailsModel(RecipeServices recipeServices)
        {
            this.recipeServices = recipeServices;
        }
        public string Message { get; set; }
        public string Display { get; set; } = "none";

        public Recipe recipedetails { get; private set; }
        [BindProperty] public RecipeDTO recipeDTO { get; set; } = new RecipeDTO();
        [BindProperty] public MainCourseDTO MainCourse { get; set; } = new MainCourseDTO();
        [BindProperty] public DrinkDTO Drink { get; set; } = new DrinkDTO();
        [BindProperty] public DessertDTO Dessert { get; set; } = new DessertDTO();
        [BindProperty] public List<Diet> SelectedDiets { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                recipedetails = recipeServices.GetRecipeById(id);
                bool matchUser = recipedetails.authorid == GetUserId();
                if (recipedetails != null && User.IsInRole("admin") || matchUser)
                {
                    recipeDTO.Id = recipedetails.recipeid;
                    recipeDTO.recipeName = recipedetails.name;
                    recipeDTO.Recipetype = recipedetails.recipetype;
                    recipeDTO.steps = recipedetails.steps;
                    recipeDTO.preptime = recipedetails.preptime;
                    recipeDTO.cooktime = recipedetails.cooktime;
                    recipeDTO.ingredients = recipedetails.Ingredients;
                    recipeDTO.description = recipedetails.desc;
                    if (recipedetails.image != null)
                    {
                        var stream = new MemoryStream(recipedetails.image);
                        recipeDTO.image = new FormFile(stream, 0, recipedetails.image.Length, $"{ValidationServices.RemoveWhitespace(recipedetails.name)}", ".jpg");
                    }
                    switch (recipedetails)
                    {
                        case MainCourse mainCourse:
                            MainCourse.cuisineType = mainCourse.cuisineType;
                            MainCourse.servingSuggestion = mainCourse.servingSuggestion;
                            SelectedDiets = mainCourse.dietaryType;
                            break;
                        case Drink drink:
                            Drink.drinkType = drink.drinkType;
                            Drink.glassType = drink.glassType;
                            Drink.alcoholic = drink.alcoholic;
                            break;
                        case Dessert dessert:
                            Dessert.dessertType = dessert.dessertType;
                            Dessert.servingMethod = dessert.servingMethod;
                            Dessert.topping = dessert.topping;
                            break;
                    }
                    return Page();
                }
                else if (!matchUser)
                {
                    return RedirectToPage("/Error");
                }
                return RedirectToPage("AddRecipe");
            }
            catch
            {
                return RedirectToPage("AddRecipe");
            }
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue("UserID"));
        }
        private void ReturnError(string msg)
        {
            Display = "block";
            Message = $"An error occured. {msg}";
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

        private void RemoveDrinkModelState()
        {
            ModelState.Remove("drinkType");
            ModelState.Remove("glassType");
            ModelState.Remove("alcoholic");
        }

        private void RemoveDessertModelState()
        {
            ModelState.Remove("dessertType");
            ModelState.Remove("servingMethod");
            ModelState.Remove("topping");
        }

        private void RemoveMainCourseModelState()
        {
            ModelState.Remove("cuisineType");
            ModelState.Remove("servingSuggestion");
            ModelState.Remove("SelectedDiets");
        }

        public IActionResult OnPostMainCourse()
        {
            try
            {
                RemoveModelState("Dessert", "Drink");
                RemoveDrinkModelState();
                RemoveDessertModelState();
                if (ModelState.IsValid)
                {
                    //MainCourse mc = Mapper.setMainCourse(recipeDTO, MainCourse, GetUserId());
                    MainCourse mc = Mapper.UpdateMainCourse(recipeDTO, MainCourse, SelectedDiets, (MainCourse)recipeServices.GetRecipeById(recipeDTO.Id));
                    recipeServices.UpdateRecipe(mc);
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
                RemoveMainCourseModelState();
                RemoveDessertModelState();
                if (ModelState.IsValid)
                {
                    Drink dr = Mapper.UpdateDrink(recipeDTO, Drink, (Drink)recipeServices.GetRecipeById(recipeDTO.Id));
                    recipeServices.UpdateRecipe(dr);
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
                RemoveDrinkModelState();
                RemoveMainCourseModelState();
                if (ModelState.IsValid)
                {
                    Dessert ds = Mapper.UpdateDessert(recipeDTO, Dessert, (Dessert)recipeServices.GetRecipeById(recipeDTO.Id));
                    recipeServices.UpdateRecipe(ds);
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
