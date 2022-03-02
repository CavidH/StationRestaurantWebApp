using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace Core.Entities
{
    public class HeadSlide
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }

        //[NotMapped]
        //public IFormFile  ImageFile { get; set; }

    }
}