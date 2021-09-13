using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Session05ArchitectureMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager { get; }
        private SignInManager<IdentityUser> signInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            
            
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel m)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = m.Email, Email = m.Email };
                var result = await userManager.CreateAsync(user, m.Password);

                if(result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    ViewBag.ErrorTitle = "Registration is successful";
                    ViewBag.ErrorMessage = "Before you log in please confirm your email by clicking " +
                        "the link in the confirmation email sent to your address: " + m.Email;

                    return View("Error");
                }

                foreach (var e in result.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            {
                RedirectToAction("Register");
            }
            var user = await userManager.FindByIdAsync(userId);
            if(user == null)
            {
                ViewBag.ErrorMessage = userId + " is invalid.";
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if(result.Succeeded)
            {
                ViewBag.ErrorMessage = "Registration Successful";
                return View("Login");
            }

            ViewBag.ErrorMessage = "Email cannot be confirmed";
            return View("Error");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
