using System.Threading.Tasks;
using Data.DAL;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private  IProductRepository _productRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository productRepository => productRepository ?? new ProductRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
