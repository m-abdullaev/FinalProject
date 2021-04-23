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
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                DOB = model.DOB,
                Email = model.Email,
                FirstName = model.FirstName,
                Gender = model.Gender,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Login
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(user,"User");
                return RedirectToAction("Login");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View(model);
        }
    }
}
