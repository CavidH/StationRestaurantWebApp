using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.Table;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Table>> GetAllAsync()
        {
            return await _unitOfWork.tableRepository.GetAllAsync(p => p.IsDeleted == false);
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
            return await _unitOfWork.tableRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task Create(TablePostVM tablePostVm)
        {
            var table = new Table()
            {
                TableNumber = tablePostVm.TableNumber,
                MaxPersonCount = tablePostVm.MaxPersonCount
            };
            await _unitOfWork.tableRepository.CreateAsync(table);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, TablePostVM tablePostVm)
        {
            #region CheckDbTable

            var dbTable = await _unitOfWork.tableRepository.GetAsync(p =>
                p.IsDeleted == false && p.TableNumber == tablePostVm.TableNumber);
            
            if (dbTable.Id != id) throw new TableException("This Table Number Already Exist");

            #endregion

            var table = await _unitOfWork.tableRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
            table.TableNumber = tablePostVm.TableNumber;
            table.MaxPersonCount = tablePostVm.MaxPersonCount;
            _unitOfWork.tableRepository.Update(table);
            await _unitOfWork.SaveAsync();
        }

        public async Task Remove(int id)
        {
            var table = await _unitOfWork
                .tableRepository
                .GetAsync(p => p.Id == id);
            if (table != null)
            {
                table.IsDeleted = true;
                _unitOfWork.tableRepository.Update(table);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<int> getPageCount(int take)
        {
            var tables = await _unitOfWork
                .tableRepository
                .GetAllAsync(p => p.IsDeleted == false);
            var tableCount = tables.Count;
            return (int) Math.Ceiling(((decimal) tableCount / take));
        }

        public async Task<bool> IsExist(int TableNumber)
        {
            var table = await _unitOfWork.tableRepository.GetAsync(p =>
                p.TableNumber == TableNumber && p.IsDeleted == false);

            if (table != null)
            {
                return true;
            }

            return false;
        }
    }
}