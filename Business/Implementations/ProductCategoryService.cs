using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.ProductCategoryVM;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return await _unitOfWork.productCategoryRepository
                  .GetAllAsync(p => p.IsDeleted == false);

        }

        public Task<ProductCategory> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Create(ProductCategoryPostVM productCategoryPostVm)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, ProductCategoryPostVM productCategoryUpdateVm)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}