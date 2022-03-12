using System.Collections.Generic;
using Core.Entities;

namespace Business.ViewModels.Home
{
    public class HomeVM
    {
        public List<Core.Entities.HeadSlide> HeadSlides { get; set; }
        public List<Product> Products { get; set; }
    }
}