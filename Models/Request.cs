using System;


namespace FinalProject.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime RequestDate { get; set; }
        public string AboutUser { get; set; }
        public string PdfPath { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Course Course { get; set; }
    }
}
