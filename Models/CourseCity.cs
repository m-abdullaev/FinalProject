using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CourseCity
    {
        public int CityId { get; set; }
        public int CourseId { get; set; }
        public virtual City City { get; set; }
        public virtual Course Course { get; set; }
    }
}
