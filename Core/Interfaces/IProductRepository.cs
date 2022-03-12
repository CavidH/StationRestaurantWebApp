using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository :IRepository<Product>
    {
        Task<List<Product>> GetLastProduct(int take);
    }
}
