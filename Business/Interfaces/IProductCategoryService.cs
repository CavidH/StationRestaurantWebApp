using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels.ProductCategoryVM;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategory> GetAsync(int id);
        Task Create(ProductCategoryPostVM productCategoryPostVm);
        Task Update(int id, ProductCategoryPostVM productCategoryUpdateVm);
        Task Remove(int id);
    }
}
