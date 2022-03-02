using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Data.DAL;
using Data.Repositories.Implementations;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private  IProductRepository _productRepository;
        private IProductCategoryRepository _productCategoryRepository;
        //12 ci setirdeki data null gele biler sebeb 20 ci setr

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository productRepository => _productRepository=_productRepository ?? new ProductRepository(_context);

        public IProductCategoryRepository productCategoryRepository => _productCategoryRepository = _productCategoryRepository ?? new ProductCategoryRepository(_context);


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
