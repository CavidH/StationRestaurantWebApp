using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels.ProductCategory;
using Business.ViewModels.ProductCategoryVM;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategory> GetAsync(int id);
        Task Create(ProductCategoryVM productCategoryVm);
        Task Update(int id, ProductCategoryVM productCategoryVm);
        Task Remove(int id);
    }
}
