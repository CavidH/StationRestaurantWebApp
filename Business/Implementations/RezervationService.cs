using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.Reservation;
using Core;
using Core.Entities;

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

        public async Task<Paginate<Reservation>> GetAllPaginatedAsync(int page)
        {
            var reservations = await _unitOfWork
                .reservationRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false);

            var Result = new Paginate<Reservation>();
            Result.Items = reservations;
            Result.CurrentPage = page;
            Result.AllPageCount = await getPageCount(10);
            return Result;
        }

        public Task<Reservation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(ReservationPostVM reservationPostVm)
        {
            var newReserv = new Reservation()
            {
                Name = reservationPostVm.Name,
                LastName = reservationPostVm.LastName,
                PhoneNumber = reservationPostVm.PhoneNumber,
                Email = reservationPostVm.Email,
                ReservDate = reservationPostVm.ReservDate,
                TableID = reservationPostVm.TableID,
                Additionals = reservationPostVm.Additionals
            };
            await _unitOfWork.reservationRepository.CreateAsync(newReserv);
            await _unitOfWork.SaveAsync();
        }

        public Task Update(int id, ReservationPostVM reservationPostVm)
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

        public async Task<int> getPageCount(int take)
        {
            var reservations = await _unitOfWork
                .reservationRepository
                .GetAllAsync(p => p.IsDeleted == false);
            var productCount = reservations.Count;
            return (int) Math.Ceiling(((decimal) productCount / take));
        }
    }
}