using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels;
using Business.ViewModels.Table;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ITableService
    {
        Task<List<Table>> GetAllAsync();
        Task<Paginate<Table>> GetAllPaginatedAsync(int page);
        Task<Table> GetAsync(int id);
        Task Create(TablePostVM tablePostVm);
        Task Update(int id, TablePostVM tablePostVm);
        Task Remove(int id);
        Task<int> getPageCount(int take);
        Task<bool> IsExist(int TableNumber);

    }
}
