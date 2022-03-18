using System;
using Microsoft.AspNetCore.Http;

namespace Business.ViewModels
{
    public class AboutVM
    {
        public string Title { get; set; }
        public string Head { get; set; }
        public string Content { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}