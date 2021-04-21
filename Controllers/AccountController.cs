using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        //[Authorize(Roles = "Admin,Moderator")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
