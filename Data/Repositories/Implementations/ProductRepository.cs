
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Data.DAL;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        //private AppDbContext _context { get; }

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Get(Expression<Func<Product, bool>> expression = null, params string[] Includes)
        {
            //IQueryable<Product> query = _context.Products.AsQueryable();
            var query = CheckQuery(Includes);
            return expression is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null, params string[] Includes)
        {
            var query = CheckQuery(Includes);
            return expression is null
                ? await query.ToListAsync()
                : await query.Where(expression).ToListAsync();
        }

        public async Task<List<Product>> GetAllPaginatedAsync(int page, int size, Expression<Func<Product, bool>> expression = null, params string[] Includes)
        {
            var query = CheckQuery(Includes);
            return expression is null
                ? await query.Skip((page - 1) * size).Take(size).ToListAsync()
                : await query.Where(expression).Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public async Task<int> GetTotalCountAsync(Expression<Func<Product, bool>> expression = null)
        {
            return expression is null
                ? await _context.Products.CountAsync()
                : await _context.Products.Where(expression).CountAsync();
        }

        public async Task<bool> IsProductExistAsync(Expression<Func<Product, bool>> expression)
        {
                 return   await _context.Products.AnyAsync(expression);
        }

        public Task CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product product)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        private IQueryable<Product> CheckQuery(params string[] Includes)
        {
            var query = _context.Products.AsQueryable();

            if (Includes != null)
            {
                foreach (var include in Includes)
                {
                    query.Include(include);
                }
            }

            return query;
        }
    }
}
