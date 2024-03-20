using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApplication.Domain.Services;
using MyApplication.Domain.Users;
using System.Security.Claims;
using Web_Application.DTO;

namespace Web_Application.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserServices userServices;
        public LoginModel(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public string display { get; set; } = "display: none;";
        public string message { get; set; }
        [BindProperty] public CredentialsDTO credentials { get; set; }

        public User user { get; private set; }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        private void ReturnError(string message)
        {
            this.message = $"Log in failed. {message}";
            display = "display: block;\rfont-family: Arial, sans-serif;\rcolor:red";
        }

        private void RemoveModelState()
        {
            ModelState.Remove("credentials.email");
            ModelState.Remove("credentials.firstname");
            ModelState.Remove("credentials.middlename");
            ModelState.Remove("credentials.lastname");
        }

        public IActionResult OnPost(string? returnUrl)
        {
            try
            {
                RemoveModelState();
                bool matchUser = userServices.CheckUsername(credentials.username);
                bool matchPass = userServices.VerifyPassword(credentials.username, credentials.password);
                if (ModelState.IsValid && matchUser && matchPass)
                {
                    user = userServices.GetUserByName(credentials.username);

                    List<Claim> claims = new List<Claim>();

                    if (user.isAdmin)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "user"));
                    }
                    claims.Add(new Claim("UserId", user.userId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, credentials.username));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                    if (!String.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToPage("Index");
                    }
                    //return RedirectToPage(returnUrl);

                }
                else if (!matchUser)
                {
                    ReturnError("user not found");
                }
                else if (!matchPass)
                {
                    ReturnError("credentials invalid");
                }
                return Page();
            }
            catch (Exception ex)
            {
                //message = $"Log in failed. {ex.Message}";
                //display = "display: block;\rfont-family: 'Arial Narrow', Arial, sans-serif;\rcolor:red";
                ReturnError(ex.Message);
                return Page();
            }
        }
    }
}
