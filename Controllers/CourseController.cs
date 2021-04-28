using FinalProject.Context;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            var courses = await context.Courses.Where(x => (categoryId != 0 ? x.CategoryId == categoryId : true)).Select(x => new CourseViewModel { Id = x.Id, Description = x.ShortDescription, Title = x.Name }).ToListAsync();
            
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

        public async Task<IActionResult> CourseDetails(int id)
        {
            var course = await context.Courses.FindAsync(id);

            var courseViewModel = new CourseViewModel { Id = course.Id, Title = course.Name, Description = course.Description };

            return View(courseViewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var createCourseViewModel = new CreateCourseViewModel 
            { 
                Categories = await context.Categories.Select(x => new CategoryViewModel { Id = x.Id, Name = x.Name }).ToListAsync(),
                Cities = await context.Cities.Select(x=> new CityViewModel { Id = x.Id, CityName = x.Name}).ToListAsync()
            };
            return View(createCourseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseViewModel model)
        {
            var course = new Course
            {
                Name = model.Name,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                CategoryId = model.CategoryId,

            };
            context.Courses.Add(course);
            await context.SaveChangesAsync();
            foreach (var item in model.CityIds)
            {
                context.CourseCities.Add(new CourseCity { CityId = item, CourseId = course.Id });

            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var courseCities = await context.CourseCities.Where(x => x.CourseId == id).ToListAsync();

            context.CourseCities.RemoveRange(courseCities);
            context.Courses.Remove(course);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await context.Courses.Where(x=>x.Id == id).Include(x=>x.CourseCities).FirstAsync();
            if (course == null)
            {
                return NotFound();
            }
            var editCourseViewModel = new EditCourseViewModel
            {
                Name = course.Name,
                Description = course.Description,
                ShortDescription = course.ShortDescription,
                CategoryId = course.CategoryId,
                CityIds = course.CourseCities.Select(x => x.CityId).ToList(),
                Id = course.Id,
                Categories = await context.Categories.Select(x => new CategoryViewModel { Id = x.Id, Name = x.Name }).ToListAsync(),
                Cities = await context.Cities.Select(x => new CityViewModel { Id = x.Id, CityName = x.Name }).ToListAsync()
            };

            return View(editCourseViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(EditCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                    var course = await context.Courses.FindAsync(model.Id);
                    course.Name = model.Name;
                    course.Description = model.Description;
                    course.ShortDescription = model.ShortDescription;
                    course.CategoryId = model.CategoryId;

                    var courseCities = await context.CourseCities.Where(x => x.CourseId == course.Id).ToArrayAsync();

                    context.CourseCities.RemoveRange(courseCities);

                    foreach (var item in model.CityIds)
                    {
                        await context.CourseCities.AddAsync(new CourseCity { CityId = item, CourseId = course.Id });
                    }
                    
                    context.Update(course);
                    await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        private bool CourseExists(int id)
        {
            return context.Courses.Any(e => e.Id == id);     
        }
    } 
}
