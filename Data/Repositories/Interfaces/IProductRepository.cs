using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll(Expression<Func<Product, bool>> expression = null, params string[] Includes);

        List<Product> GetAllPaginated(int page, int size, Expression<Func<Product, bool>> expression = null,
            params string[] Includes);

        Product Get(Expression<Func<Product, bool>> expression = null, params string[] Includes);
        int GetTotalCount(Expression<Func<Product, bool>> expression = null);
        bool IsProductExist(Expression<Func<Product, bool>> expression = null);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        void Remove(Product product);
        Task SaveAsync();

    }
}
