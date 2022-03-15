using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetLastProductsAsync();
        Task<Paginate<Product>> GetAllPaginatedAsync(int page);
        Task<Product> GetAsync(int id);
        Task Create(ProductPostVM productPostVm);
        Task Update(int id, ProductUpdateVM productUpdateVm);
        Task Remove(int id);
        Task<int> getPageCount(int take);
        // Task<int> getLastIdAsync();
    }
}
