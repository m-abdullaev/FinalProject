using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class CreateRequestViewModel
    {
        public int CourseId { get; set; }
        public string AboutUser { get; set; }
        public IFormFile Pdf{ get; set; }
    }
}
