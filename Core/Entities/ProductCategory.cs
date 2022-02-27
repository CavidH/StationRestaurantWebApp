using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  DateTime CreatedAt { get; set; }
        public bool IsDeleted{ get; set; }
        public List<Product> Products { get; set; }
    }
}
