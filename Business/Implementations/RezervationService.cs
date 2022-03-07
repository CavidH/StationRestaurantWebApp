using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core;
using Core.Entities;
using Data.DAL;

namespace Business.Implementations
{
    public class RezervationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RezervationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<Reservation>> GetAllPaginatedAsync(int page)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Create(ProductPostVM productPostVm)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, ProductUpdateVM productUpdateVm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsReserved(DateTime dateTime, int tableId)
        {
            var table = await _unitOfWork.tableRepository.GetWithRezervsAsync(tableId);
            if (table.Reservations.Count == 0) return false;

            if (table.Reservations.Where(p => p.ReservDate.Date == dateTime.Date).FirstOrDefault() != null)
            {
                return true;
            }

            return false;

            // var allDbTables = await _unitOfWork
            //      .tableRepository
            //    .GetAllAsync(p=>p.IsDeleted==false,"Reservations");
            // var allDbTables = await _context.Tables.Include(p=>p.Reservations).ToListAsync();
            // var emptyTables = new List<Table>();
            // foreach (var table in allDbTables)
            // {
            //     foreach (var rezerv in table.Reservations)
            //     {
            //         // rezerv.ReservDate.Date == dateTime.Date
            //     }
            // }

            // for (int i = 0; i < allDbTables.Count; i++)
            // {
            //     var rezev = allDbTables[i].Reservations.Where(p => p.ReservDate.Date == dateTime.Date).ToList();
            //     if (rezev.Count==0)
            //     {
            //         emptyTables.Add(allDbTables[i]);
            //     }
            // }

            // return true;
            // return true;
        }


        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}