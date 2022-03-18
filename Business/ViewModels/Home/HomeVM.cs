using System.Collections.Generic;
using Core.Entities;

namespace Business.ViewModels.Home
{
    public class HomeVM
    {
        public List<Core.Entities.HeadSlide> HeadSlides { get; set; }
        public List<Product> Products { get; set; }
        public List<GaleryImage> MiniGallery { get; set; }
        public Dictionary<string, string> Settings { get; set; }

        public Core.Entities.About About { get; set; }
    }
}