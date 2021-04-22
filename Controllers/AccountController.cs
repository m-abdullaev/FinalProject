using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new SignInViewModel { ReturnUrl = returnUrl });
        }

        public async Task<IActionResult> Login(SignInViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);

            if(result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "/Home/Index");
            }

            ModelState.AddModelError("Signin", "Login or password incorrect");

            return View(model);
        }
    }
}
