using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Seeds
{
    public class DefaultUsers
    {
        public static async Task AddDefaultAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = await userManager.FindByNameAsync("Admin");
            if(admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    Gender = 'M'
                };
                await userManager.CreateAsync(admin, "@dmin123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
            var user = await userManager.FindByNameAsync("User");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "User",
                    Email = "User@gmail.com",
                    Gender = 'M'
                };
                await userManager.CreateAsync(user, "@dmin123");
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
