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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        }
    }
}
