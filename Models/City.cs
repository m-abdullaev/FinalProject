using System.Collections.Generic;


namespace FinalProject.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseCity> CourseCities { get; set; }
    }
}
