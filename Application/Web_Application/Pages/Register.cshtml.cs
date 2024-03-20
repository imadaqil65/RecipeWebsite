using MyApplication.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MyApplication.Domain.Services;
using Web_Application.DTO;

namespace Web_Application.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserServices userServices;

        public RegisterModel(UserServices userServices)
        {
            this.userServices = userServices;
        }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public string Message { get; set; } = null;
        public string Display { get; set; } = "display:none;";

        [BindProperty] public CredentialsDTO register { get; set; }
        private void RemoveModelState()
        {
            ModelState.Remove("register.middlename");
            ModelState.Remove("register.lastname");
            ModelState.Remove("register.firstname");
        }
        private void ReturnError(string message)
        {
            Message = message;
            Display = "display: block;\rfont-family: Arial, sans-serif;\rcolor:red;";
        }

        public IActionResult OnPost()
        {
            try
            {
                RemoveModelState();
                if (ModelState.IsValid && !userServices.CheckEmail(register.email) && !userServices.CheckUsername(register.username))
                {
                    userServices.CreateUser(new User(register.username, userServices.HashPassword(register.password), register.email, false, true));
                    ReturnError("Account Created, You can now login");
                }
                else
                {
                    ReturnError("Email or Username already exist. Please use another");
                }
                return Page();
            }
            catch(Exception ex)
            {
                ReturnError($"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
