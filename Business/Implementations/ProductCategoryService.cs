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

        public async Task<ProductCategory> GetAsync(int id)
        {
            //exceptionlari nezereal
            var category = await _unitOfWork
                .productCategoryRepository
                .GetAsync(p => p.Id == id && p.IsDeleted==false );
            return category;   

        }

        public async Task Create(ProductCategoryVM productCategoryVm)
        {
            var p = new ProductCategory()
            {
                Name = productCategoryVm.Name

            };
            await _unitOfWork.productCategoryRepository.CreateAsync(p);
            await _unitOfWork.SaveAsync();
            //productCategoryPostVm.Name
        }

        public async Task Update(int id, ProductCategoryVM productCategoryVm)
        {

            //exceptionlari nezere al
            var category = await _unitOfWork
                .productCategoryRepository
                .GetAsync(p => p.Id == id);
            category.Name = productCategoryVm.Name;
            _unitOfWork
                .productCategoryRepository
                .Update(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task Remove(int id)
        {
            if (id == 0)
            {
                //id exception
            }
            var category = await _unitOfWork
                .productCategoryRepository
                .GetAsync(p => p.Id == id);
            if (category == null)
            {
                // category not found
            }
            category.IsDeleted = true;

            _unitOfWork.productCategoryRepository.Update(category);
            await _unitOfWork.SaveAsync();
        }
    }
}