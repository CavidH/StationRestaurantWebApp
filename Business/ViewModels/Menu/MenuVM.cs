using System.Collections.Generic;
using Core.Entities;

namespace Business.ViewModels.Menu
{
    public class MenuVM
    {
        public List<Core.Entities.ProductCategory> ProductCategories { get; set; }
        public List<Product> Products { get; set; }
    }
}