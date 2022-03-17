using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Business.Implementations
{
    public class ProductService : IProductService

        //biznesdeki servislerin unit of vorkin yaz ve controllerlere inject ele
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;


        public ProductService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _unitOfWork
                .productRepository
                .GetAllAsync(p => p.IsDeleted == false && p.ProductCategory.IsDeleted == false,
                    "ProductCategory");
        }

        public async Task<List<Product>> GetLastProductsAsync()
        {
            return await _unitOfWork
                .productRepository
                .GetLastProduct(4);
        }

        public async Task<Paginate<Product>> GetAllPaginatedAsync(int page)
        {
            var products = await _unitOfWork
                .productRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false && p.ProductCategory.IsDeleted == false,
                    "ProductCategory");

            var Result = new Paginate<Product>();
            Result.Items = products;
            Result.CurrentPage = page;
            Result.AllPageCount = await getPageCount(10);
            return Result;
        }

        public async Task<int> getPageCount(int take)
        {
            var products = await _unitOfWork
                .productRepository
                .GetAllAsync(p => p.IsDeleted == false && p.ProductCategory.IsDeleted == false,
                    "ProductCategory");
            var productCount = products.Count;
            return (int) Math.Ceiling(((decimal) productCount / take));
        }

        // public async Task<int> getLastIdAsync()
        // {
        //     var product = await _unitOfWork.productRepository
        //         .GetAllAsync(p => p.IsDeleted == false);
        //     return product[product.Count-1].Id;
        // }

        public async Task<Product> GetAsync(int id)
        {
            var product = await _unitOfWork
                .productRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false ,"ProductCategory","Comments");
            if (product == null) return null;
            return product;
        }

        public async Task Create(ProductPostVM productPostVm)
        {
            string imageFile = await productPostVm.ImageFile.SaveFileAsync(_environment.WebRootPath, "Assets", "img");

            var product = new Product()
            {
                Name = productPostVm.Name,
                Description = productPostVm.Description,
                Title = productPostVm.Title,
                ProductCategoryID = productPostVm.ProductCategoryID,
                Image = imageFile,
                Price = productPostVm.Price
            };
            await _unitOfWork.productRepository.CreateAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, ProductUpdateVM productUpdateVm)
        {
            var product = await _unitOfWork.productRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
            if (productUpdateVm.ImageFile != null)
            {
                string imageFile = await productUpdateVm
                    .ImageFile
                    .SaveFileAsync(_environment.WebRootPath, "Assets", "img");
                product.Image = imageFile;
            }

            product.Id = id;
            product.Name = productUpdateVm.Name;
            product.Title = productUpdateVm.Title;
            product.Description = productUpdateVm.Description;
            product.ProductCategoryID = productUpdateVm.ProductCategoryID;
            product.Price = productUpdateVm.Price;
            _unitOfWork.productRepository.Update(product);
            await _unitOfWork.SaveAsync();


            // _unitOfWork.productRepository.Update(product);
            // await _unitOfWork.SaveAsync();
        }

        public async Task Remove(int id)
        {
            var product = await _unitOfWork
                .productRepository
                .GetAsync(p => p.Id == id);
            if (product != null)
            {
                product.IsDeleted = true;
                _unitOfWork.productRepository.Update(product);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}