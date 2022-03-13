using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Business.ViewModels.ProductVM
{
    public class ProductPostVM
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductCategoryID { get; set; }
        public double Price { get; set; }
        public IFormFile ImageFile { get; set; }
        // public List<Core.Entities.ProductCategory> ProductCategories { get; set; }
    }
}