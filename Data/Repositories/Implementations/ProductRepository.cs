
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
            var query = GetQuery(Includes);

            return expression is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(expression).FirstOrDefaultAsync();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> expression = null, params string[] Includes)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllPaginated(int page, int size, Expression<Func<Product, bool>> expression = null, params string[] Includes)
        {
            throw new NotImplementedException();
        }

        public int GetTotalCount(Expression<Func<Product, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public bool IsProductExist(Expression<Func<Product, bool>> expression = null)
        {
            throw new NotImplementedException();
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

        private IQueryable<Product> GetQuery(params string[] Includes)
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
