using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCity> CourseCities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CourseCity>().HasKey(x => new { x.CityId, x.CourseId });

            builder.Entity<City>(opt =>
            {
                opt.Property(x => x.Name).IsRequired(true);
                opt.HasData(
                    new City { Id = 1, Name = "Dushanbe"},
                    new City { Id = 2, Name = "Khudjand"},
                    new City { Id = 3, Name = "Kulob"},
                    new City { Id = 4, Name = "Farkhor"}
                    );
            });

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "QA" },
                new Category { Id = 2, Name = "Back-end" },
                new Category { Id = 3, Name = "Front-end" }
                );

            builder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Java script lvl 0", CategoryId = 3, Description = "<h1>Test Header</h1><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim!" },
                new Course { Id = 2, Name = "C#", CategoryId = 2, Description = "<h2>Test Header for c#</h2><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>" , ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." },
                new Course { Id = 3, Name = "PHP", CategoryId = 2, Description = "<h2>Test Header for php</h2><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>" , ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." },
                new Course { Id = 4, Name = "Go Lang", CategoryId = 2, Description = "<h2>Test Header for go lang</h2><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>" , ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." },
                new Course { Id = 5, Name = "Quality assurance" , CategoryId = 1, Description = "<h2>Test Header for QA</h2><ul><li>Item1</li><li>Item2</li></ul><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." }
                );

            builder.Entity<CourseCity>().HasData(
                new CourseCity { CityId = 1, CourseId = 1 },
                new CourseCity { CityId = 2, CourseId = 1 },
                new CourseCity { CityId = 3, CourseId = 1 },
                new CourseCity { CityId = 1, CourseId = 2 },
                new CourseCity { CityId = 2, CourseId = 2 },
                new CourseCity { CityId = 3, CourseId = 2 },
                new CourseCity { CityId = 4, CourseId = 2 },
                new CourseCity { CityId = 1, CourseId = 3 },
                new CourseCity { CityId = 2, CourseId = 3 },
                new CourseCity { CityId = 1, CourseId = 4 },
                new CourseCity { CityId = 2, CourseId = 4 },
                new CourseCity { CityId = 1, CourseId = 5 },
                new CourseCity { CityId = 2, CourseId = 5 }
                );

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        }
    }
}
