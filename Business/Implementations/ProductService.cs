using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class ProductService :IProductService
    
    //biznesdeki servislerin unit of vorkin yaz ve controllerlere inject ele
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Product>> GetAllAsync()
        {
            
            //algorithm expetion ve s
            throw new System.NotImplementedException();
        }

        public async Task<Paginate<Product>> GetAllPaginatedAsync(int page)
        {
            var products = await _unitOfWork
                .productRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false,"ProductCategory");

            var rt = new Paginate<Product>();
            rt.Items=products;
            rt.CurrentPage = page;
            rt.AllPageCount = await getPageCount(10);
            return rt;
        }
        private async Task<int> getPageCount(int take)
        {
            var products = await _unitOfWork
                .productRepository
                .GetAllAsync(p => p.IsDeleted == false);
            var productCount = products.Count;
            return (int)Math.Ceiling(((decimal)productCount / take));
        }

        public Task<Product> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Create(ProductVM productPostVm)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, ProductUpdateVM productUpdateVm)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}