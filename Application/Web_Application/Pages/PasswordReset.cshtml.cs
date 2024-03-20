using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApplication.Domain.Services;
using MyApplication.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Web_Application.Pages
{
    public class PasswordResetModel : PageModel
    {
        private readonly UserServices userServices;
        private User user { get; set; }
        public string display { get; set; } = "display: none;";
        public string message { get; set; }


        [BindProperty, Required, EmailAddress]
        public string Email { get; set; }
        [BindProperty, Required, MinLength(8, ErrorMessage = "Password not valid"), MaxLength(18)]
        public string Password { get; set; }
        

        public PasswordResetModel(UserServices userServices)
        {
            this.userServices = userServices;
        }

        private bool isEmail(string email)
        {
            Regex EmailValidation = new Regex("^\\S+@\\S+\\.\\S+$");
            return EmailValidation.IsMatch(email);
        }

        private bool ValidPassword(string pass)
        {
            Regex PasswordValidation = new Regex("");
            return PasswordValidation.IsMatch(pass);
        }
        private void ReturnError(string message)
        {
            this.message = $"Log in failed. {message}";
            display = "display: block;\rfont-family: Arial, sans-serif;\rcolor:red";
        }

        public IActionResult OnGet()
        {
            if(User.Identity.IsAuthenticated)
                HttpContext.SignOutAsync();
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                if (isEmail(Email) && ModelState.IsValid)
                {
                    user = userServices.GetUserByName(Email);
                    user.SetPassword(Password);
                    userServices.UpdateUser(user);

                    return RedirectToPage("/Login");
                }
                ReturnError(string.Empty);
                return Page();
            }
            catch(Exception ex)
            {
                ReturnError(ex.Message);
                return Page();
            }
        }
    }
}
