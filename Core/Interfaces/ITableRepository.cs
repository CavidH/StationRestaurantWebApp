using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITableRepository:IRepository<Table>
    {
        //Task<List<Table>> GetAllWithRezervsAsync();
        //Task<Table> GetWithRezervsAsync(int id);

    }
}
