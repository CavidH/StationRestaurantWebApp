using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetLastProduct(int take)
        {
            return await _context
                .Products
                .Where(p => p.IsDeleted == false)
                .Include(p=>p.ProductCategory)
                .OrderByDescending(p => p.Id)
                .Take(take)
                .ToListAsync();
        }
    }
}