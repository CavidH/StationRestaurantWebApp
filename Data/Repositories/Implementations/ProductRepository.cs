using Core.Entities;
using Data.DAL;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

    }

}
