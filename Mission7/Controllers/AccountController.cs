using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> UM, SignInManager<IdentityUser> SM)
        {
            userManager = UM;
            signInManager = SM;
        }

        [HttpGet]
        public IActionResult Login(string ReturnURL)
        {
            return View(new LoginModel { ReturnURL = ReturnURL });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(lm.UserName);

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    if ((await signInManager.PasswordSignInAsync(user, lm.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction(lm?.ReturnURL ?? "Admin");
                    }
                }

                
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View(lm);
        }
        public async Task<IActionResult> Logout(string returnURL = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnURL);
        }
    }
}
