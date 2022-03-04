using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels.ProductCategory;
using Business.ViewModels.ProductCategoryVM;
using Core.Entities;
using Data.Utilities.Interfaces;

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
        Task<ProductCategory> GetAsync(int id);
        Task Create(ProductCategoryVM productCategoryVm);
        Task Update(int id, ProductCategoryVM productCategoryVm);
        Task Remove(int id);
    }
}
