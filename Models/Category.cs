using System.Collections.Generic;


namespace FinalProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
