using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core.Entities;

namespace Business.Implementations
{
    public class TableService:ITableService
    {
        public async Task<List<Table>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Paginate<Table>> GetAllPaginatedAsync(int page)
        {
            throw new NotImplementedException();
        }

        public async Task<Table> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(ProductPostVM productPostVm)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, ProductUpdateVM productUpdateVm)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
