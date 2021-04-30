using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class RequestViewModel
    {
        public DateTime RequestDate { get; set; }
        public string AboutUser { get; set; }
        public string UserName { get; set; }
        public string PdfPath { get; set; }
        public string CourseName { get; set; }
    }
}
