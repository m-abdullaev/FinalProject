using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


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
        public DbSet<Request> Requests { get; set; }

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
                new Course { Id = 1, Name = "Java script lvl 0", CategoryId = 3, Description = "<h1>Java script</h1><p>JavaScript® (often shortened to JS) is a lightweight, interpreted, object-oriented language with first-class functions, and is best known as the scripting language for Web pages, but it's used in many non-browser environments as well. It is a prototype-based, multi-paradigm scripting language that is dynamic, and supports object-oriented, imperative, and functional programming styles.</p>", ShortDescription = "JavaScript® (often shortened to JS) is a lightweight, interpreted, object-oriented language with first-class functions, and is best known as the scripting language for Web pages, but it's used in many non-browser environments as well." },
                new Course { Id = 2, Name = "C#", CategoryId = 2, Description = "<h2>C# (C-Sharp)</h2><p>C# is a modern, general purpose, object-oriented programming language designed around the Common Language Infrastructure. A great C# developer is capable of handling many aspects of developing an application, including but not limited to performance, scalability, security, testing, and more. C# developers can develop modern applications that run on desktop computers, or even sophisticated back-end processes powering modern web applications. The frameworks .Net and Mono combined allow a wide range of platforms to be targeted by applications developed with C#.</p>", ShortDescription = "C# is a modern, general purpose, object-oriented programming language designed around the Common Language Infrastructure." },
                new Course { Id = 3, Name = "PHP", CategoryId = 2, Description = "<h2>PHP</h2><p>PHP is a server side scripting language. that is used to develop Static websites or Dynamic websites or Web applications. PHP stands for Hypertext Pre-processor, that earlier stood for Personal Home Pages.PHP scripts can only be interpreted on a server that has PHP installed.</p>", ShortDescription = "PHP is a server side scripting language. that is used to develop Static websites or Dynamic websites or Web applications." },
                new Course { Id = 4, Name = "Go Lang", CategoryId = 2, Description = "<h2>Go Lang</h2><p>Go (also called Golang or Go language) is an open source programming language used for general purpose. Go was developed by Google engineers to create dependable and efficient software. Most similarly modeled after C, Go is statically typed and explicit.The language was designed by taking inspiration for the productivity and relative simplicity of Python, with the ability of C.Some of the problems that Go addresses are slow build time, uncontrolled dependencies, effort duplication, difficulty of writing automatic tools and cross - language development.</p>", ShortDescription = "Go (also called Golang or Go language) is an open source programming language used for general purpose. Go was developed by Google engineers to create dependable and efficient software. Most similarly modeled after C, Go is statically typed and explicit." },
                new Course { Id = 5, Name = "Quality assurance" , CategoryId = 1, Description = "<h2>Quality Assurance</h2><ul><li>Item1</li><li>Item2</li></ul><p>A quality assurance specialist ensures that the final product observes the company's quality standards. In general, these detail-oriented professionals are responsible for the development and implementation of inspection activities, the detection and resolution of problems, and the delivery of satisfactory outcomes.</p>", ShortDescription = "A quality assurance specialist ensures that the final product observes the company's quality standards." }
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
