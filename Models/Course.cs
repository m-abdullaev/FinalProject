
using System.Collections.Generic;


namespace FinalProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<CourseCity> CourseCities { get; set; }

    }
}
