using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductCategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string Image { get; set; }
        //public List<ProductImage> ProductImages { get; set; }



    }
}
