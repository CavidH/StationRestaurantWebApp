using Microsoft.AspNetCore.Http;

namespace Business.ViewModels.ProductVM
{
    public class ProductUpdateVM
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductCategoryID { get; set; }
        public IFormFile ImageFile { get; set; }
        // public List<Core.Entities.ProductCategory> ProductCategories { get; set; }
    }
}
