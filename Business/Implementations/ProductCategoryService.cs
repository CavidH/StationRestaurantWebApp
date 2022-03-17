using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.ProductCategory;
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

        public async Task<Paginate<ProductCategory>> GetAllPaginatedAsync(int page)
        {
            var productCategories = await _unitOfWork
                .productCategoryRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false, "Products");

            var Result = new Paginate<ProductCategory>
            {
                Items = productCategories,
                CurrentPage = page,
                AllPageCount = await getPageCount(10)
            };
            return Result;
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return await _unitOfWork
                .productCategoryRepository
                .GetAllAsync(p => p.IsDeleted == false, "Products");
        }

        public async Task<ProductCategoryVM> GetAsync(int id)
        {
            //exceptionlari nezereal
            var category = await _unitOfWork
                .productCategoryRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
            if (category == null) return null;
            return new ProductCategoryVM() {Name = category.Name};
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

        public async Task<bool> IsExits(int id)
        {
            return await _unitOfWork
                .productCategoryRepository
                .IsExistAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task Remove(int id)
        {
            var category = await _unitOfWork
                .productCategoryRepository
                .GetAsync(p => p.Id == id);
            if (category != null)
            {
                category.IsDeleted = true;
                _unitOfWork.productCategoryRepository.Update(category);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<int> getPageCount(int take)
        {
            var categories = await _unitOfWork
                .productCategoryRepository
                .GetAllAsync(p => p.IsDeleted == false, "ProductCategory");
            var categoriesCount = categories.Count;
            return (int) Math.Ceiling(((decimal) categoriesCount / take));
        }
    }
}