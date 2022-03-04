using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels.ProductCategory;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IProductCategoryService
    {
        //Task<IDataResult<List<ProductCategory>>> GetAllAsync();
        //Task<ProductCategory> GetAsync(int id);
        //Task Create(ProductCategoryVM productCategoryVm);
        //Task Update(int id, ProductCategoryVM productCategoryVm);
        //Task Remove(int id);
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategoryVM> GetAsync(int id);
        Task Create(ProductCategoryVM productCategoryVm);
        Task Update(int id, ProductCategoryVM productCategoryVm);
        Task<bool> IsExits(int id);
        Task Remove(int id);
    }
}
