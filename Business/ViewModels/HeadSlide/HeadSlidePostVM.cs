using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Business.ViewModels.HeadSlide
{
    public class HeadSlidePostVM
    {
        public List<IFormFile> FormFiles { get; set; }
    }
}
