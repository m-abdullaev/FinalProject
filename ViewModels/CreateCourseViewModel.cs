using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class CreateCourseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public List<int> CityIds { get; set; }
        public int CategoryId { get; set; }

        public List<CategoryViewModel> Categories {get; set;}
        public List<CityViewModel> Cities { get; set; }
    }
}
