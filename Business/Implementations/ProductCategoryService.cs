using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.ProductCategoryVM;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class ProductCategoryService:IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
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