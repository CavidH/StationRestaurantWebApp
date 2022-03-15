using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Business.ViewModels.Gallery
{
    public class GalleryPostVM
    {
        public List<IFormFile> ImageFiles { get; set; }
    }
}