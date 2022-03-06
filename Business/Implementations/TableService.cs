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
    public class TableService:ITableService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Table>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Paginate<Table>> GetAllPaginatedAsync(int page)
        {
            var tables = await _unitOfWork
                .tableRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false);

            var Result = new Paginate<Table>();
            Result.Items = tables;
            Result.CurrentPage = page;
            Result.AllPageCount = await getPageCount(10);
            return Result;
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

        public async Task<int> getPageCount(int take)
        {
            var tables = await _unitOfWork
                .tableRepository
                .GetAllAsync(p => p.IsDeleted == false);
            var tableCount = tables.Count;
            return (int)Math.Ceiling(((decimal)tableCount / take));
        }
    }
}
