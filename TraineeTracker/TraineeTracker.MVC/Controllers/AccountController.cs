using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string? returnUrl)
        {
            if (ModelState.IsValid)
            {                
                returnUrl ??= Url.Content("~/");
                var isLoggedIn = await _authService.Authenticate(login.Email, login.Password);
                if (isLoggedIn)
                {                  
                    //TempData["Name"] = HttpContext.Session.GetString("_Name");
                    return LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            //if(!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("_Name")))
            //    HttpContext.Session.Remove("_Name");

            returnUrl ??= Url.Content("~/");
            await _authService.Logout();
            return LocalRedirect(returnUrl);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ProfileVM profile)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.ChangePassword(profile);
                if (response.Succeeded)
                {
                    TempData["success"] = "Password changed successfully";
                    return View(profile);
                }
                ModelState.AddModelError("", response.Errors.First());
            }

            return View(profile);
        }
    }
}
