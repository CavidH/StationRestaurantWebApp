using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class ProductCategoryRepository:Repository<ProductCategory>,IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        
    }
}