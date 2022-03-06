using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ITableService
    {
        Task<List<Table>> GetAllAsync();
        Task<Paginate<Table>> GetAllPaginatedAsync(int page);
        Task<Table> GetAsync(int id);
        Task Create(ProductPostVM productPostVm);
        Task Update(int id, ProductUpdateVM productUpdateVm);
        Task Remove(int id);
    }
}
