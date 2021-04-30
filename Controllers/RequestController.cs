using FinalProject.Context;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        private readonly UserManager<ApplicationUser> userManager;

        public RequestController(ApplicationDbContext context, IWebHostEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.environment = environment;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var currentUser = await userManager.GetUserAsync(User);
            bool isAdmin = User.IsInRole("Admin");
            var requests = await context.Requests.Where(x => isAdmin ? true: x.UserId == currentUser.Id).Include(x => x.Course).Include(x => x.User).Select(x => new RequestViewModel
            {
                AboutUser = x.AboutUser,
                CourseName = x.Course.Name,
                PdfPath = x.PdfPath,
                RequestDate = x.RequestDate,
                UserName = x.User.UserName
            }).ToListAsync();

            return View(requests);
        }

        [Authorize]
        public IActionResult Create(int id  )
        {
            var model = new CreateRequestViewModel
            {
                CourseId = id
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var request = new Request
            {
                CourseId = model.CourseId,
                AboutUser = model.AboutUser,
                PdfPath = model.Pdf != null ? $"/pdfs/{model.Pdf.FileName}" : null,
                RequestDate = DateTime.Now,
                UserId = currentUser.Id                
            };

            if(model.Pdf != null)
            {
                string directoryPath = environment.WebRootPath + "/pdfs";

                if(!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string pdfPath = directoryPath + $"/{model.Pdf.FileName}";

                using(FileStream fs = new FileStream(pdfPath, FileMode.Create))
                {
                    await model.Pdf.CopyToAsync(fs);
                }
            }

            await context.Requests.AddAsync(request);
            await context.SaveChangesAsync();
            return RedirectToAction("CourseDetails", "Course", new { id = model.CourseId});
        }
    }
}
