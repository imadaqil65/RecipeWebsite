using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Services;
using MyApplication.Domain.Users;
using Web_Application.DTO;

namespace Web_Application.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserServices userServices;
        private readonly RecipeServices recipeServices;
        public string Message { get; set; } = string.Empty;
        public string display { get; set; } = "none";
        public IReadOnlyCollection<Recipe> YourRecipes { get; private set; } = new List<Recipe>();
        public IReadOnlyCollection<Recipe> FavRecipes { get; private set; } = new List<Recipe>();

        public int userId { get; private set; }
        public User account { get; private set; }

        [BindProperty] public CredentialsDTO profile { get; set; }

        public ProfileModel(UserServices userServices, RecipeServices recipeServices)
        {
            this.userServices = userServices;
            this.recipeServices = recipeServices;
            profile = new CredentialsDTO();
        }
        public void OnGet()
        {
            try
            {
                account = userServices.GetUserByName(User.Identity.Name);
                userId = account.userId;
                profile.username = account.username;
                profile.firstname = account.firstname;
                profile.middlename = account.middlename;
                profile.lastname = account.lastname;
                profile.email = account.email;

                switch (account.isAdmin)
                {
                    case true:
                        YourRecipes = new List<Recipe>(recipeServices.ViewAllRecipes());
                        break;
                    case false:
                        YourRecipes = new List<Recipe>(recipeServices.ViewRecipesFromUser(userId));
                        break;
                }
                FavRecipes = new List<Recipe>(recipeServices.ViewUserFavorites(userId));
            }
            catch (Exception ex)
            {
                ReturnError(ex);
            }
        }

        private void ReturnError(Exception ex)
        {
            Message = ex.Message;
            display = "block";
        }

        private void ReturnError(string s)
        {
            Message = s;
            display = "block";
        }

        public IActionResult OnPostProfileUpdate()
        {
            try
            {
                account = userServices.GetUserByName(User.Identity.Name);
                if (profile.firstname != account.firstname || profile.middlename != account.middlename || profile.lastname != account.lastname)
                    account.setName(profile.firstname, profile.middlename, profile.lastname);
                if (profile.username != account.username && !userServices.CheckUsername(profile.username))
                {
                    account.setUsername(profile.username);
                }
                else if (profile.username != account.username && userServices.CheckEmail(profile.email))
                {
                    ReturnError("username is already in use");
                    return Page();
                }

                if (profile.email != account.email && !userServices.CheckEmail(profile.email))
                {
                    account.setEmail(profile.email);
                }
                else if (profile.email != account.email && userServices.CheckEmail(profile.email))
                {
                    ReturnError("email is already in use");
                    return Page();
                }

                ModelState.Remove("profile.password");
                if (ModelState.IsValid)
                {
                    userServices.UpdateUser(account);
                }
                return Page();
            }
            catch (Exception ex)
            {
                ReturnError(ex);
                return Page();
            }
        }

        public IActionResult OnPostDeleteRecipe(int id)
        {
            try
            {
                recipeServices.DeleteRecipes(id);
                return RedirectToPage("Profile");
            }
            catch (Exception ex)
            {
                ReturnError(ex);
                return Page();
            }
        }

        public IActionResult OnPostDeleteAccount(int id)
        {
            try
            {
                userServices.DeleteUser(id);
                return RedirectToPage("Logout");
            }
            catch (Exception ex)
            {
                ReturnError(ex);
                return Page();
            }
        }

        public IActionResult OnPostEditDetails(int id)
        {
            try
            {
                return RedirectToPage("EditDetails", new { id });
            }
            catch (Exception ex)
            {
                ReturnError(ex);
                return Page();
            }
        }
    }
}
