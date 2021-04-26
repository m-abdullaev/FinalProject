using FinalProject.Context;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext context;

        public CourseController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index(int categoryId, int cityId)
        {
            var courses = await context.Courses.Where(x => (categoryId != 0 ? x.CategoryId == categoryId : true)).Select(x => new CourseViewModel { Id = x.Id, ShorDescription = x.ShortDescription, Title = x.Name }).ToListAsync();
            
            if(cityId != 0) 
            {
                var cityCoursesId = await context.CourseCities.Where(x => x.CityId == cityId).Select(x=>x.CourseId).ToListAsync();

                courses = courses.Where(x => cityCoursesId.Contains(x.Id)).ToList();
            }
            
            var model = new CourseIndexViewModel
            {
                Categories = await context.Categories.Select(x => new CategoryViewModel { Id = x.Id, Name = x.Name }).ToListAsync(),
                Cities = await context.Cities.Select(x => new CityViewModel { Id = x.Id, CityName = x.Name }).ToListAsync(),
                Courses = courses
            };
            return View(model);
        }
    }
}
