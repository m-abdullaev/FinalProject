using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class CourseIndexViewModel
    {
        public List<CourseViewModel> Courses { get; set; }
        public List<CityViewModel> Cities { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
