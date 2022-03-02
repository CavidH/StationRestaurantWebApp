using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
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

        public Task<Product> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Create(ProductPostVM productPostVm)
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