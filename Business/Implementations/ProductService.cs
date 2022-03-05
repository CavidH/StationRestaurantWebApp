using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core;
using Core.Entities;
using Data.DAL;
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

        public Task<List<Product>> GetAllAsync()
        {
            //algorithm expetion ve s
            throw new System.NotImplementedException();
        }

        public async Task<Paginate<Product>> GetAllPaginatedAsync(int page)
        {
            var products = await _unitOfWork
                .productRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false, "ProductCategory");

            var rt = new Paginate<Product>();
            rt.Items = products;
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
            return (int) Math.Ceiling(((decimal) productCount / take));
        }

        public async Task<Product> GetAsync(int id)
        {
            var category = await _unitOfWork
                .productRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
            if (category == null) return null;
            return category;
        }

        public async Task Create(ProductPostVM productPostVm)
        {
            string imageFile = await productPostVm.ImageFile.SaveFileAsync(_environment.WebRootPath, "Assets", "img");
            // slide.Image = filename;
            // await _context.Sliders.AddAsync(slide);
            // await _context.SaveChangesAsync();

            var product = new Product()
            {
                Name = productPostVm.Name,
                Description = productPostVm.Description,
                Title = productPostVm.Title,
                ProductCategoryID = productPostVm.ProductCategoryID,
                Image = imageFile
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
            product.Id= id;
            product.Name = productUpdateVm.Name;
            product.Title = productUpdateVm.Title;
            product.Description = productUpdateVm.Description;
            product.ProductCategoryID = productUpdateVm.ProductCategoryID;
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