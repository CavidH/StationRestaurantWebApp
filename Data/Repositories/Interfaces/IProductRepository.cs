using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Get(Expression<Func<Product, bool>> expression = null, params string[] Includes);
        Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null, params string[] Includes);
        Task<List<Product>> GetAllPaginatedAsync(int page, int size, Expression<Func<Product, bool>> expression = null, params string[] Includes);
        Task<int> GetTotalCountAsync(Expression<Func<Product, bool>> expression = null);
        Task<bool> IsProductExistAsync(Expression<Func<Product, bool>> expression);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        void Remove(Product product);
        Task SaveAsync();

    }
}
