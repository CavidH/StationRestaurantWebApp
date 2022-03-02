using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        Task Create(ProductPostVM productPostVm);
        Task Update(int id, ProductUpdateVM productUpdateVm);
        Task Remove(int id);
    }
}
