using Microsoft.AspNetCore.Http;


namespace FinalProject.ViewModels
{
    public class CreateRequestViewModel
    {
        public int CourseId { get; set; }
        public string AboutUser { get; set; }
        public IFormFile Pdf{ get; set; }
    }
}
