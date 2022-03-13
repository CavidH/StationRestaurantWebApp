using System;
using System.Collections.Generic;
using Core.Entities;

namespace Business.ViewModels.ProductVM
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductCategoryID { get; set; }
        public double Price { get; set; }
        public  Core.Entities.ProductCategory ProductCategory { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
