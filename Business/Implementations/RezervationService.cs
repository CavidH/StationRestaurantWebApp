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

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _unitOfWork
                .reservationRepository
                .GetAllAsync(p => p.IsDeleted == false, "Table", "TimeInterval");
        }

        public async Task<List<Reservation>> GetAllStatAsync()
        {
            return await _unitOfWork
                .reservationRepository
                .GetAllAsync(p => p.Name != null, "Table", "TimeInterval");
        }

        public async Task<Paginate<Reservation>> GetAllPaginatedAsync(int page)
        {
            var reservations = await _unitOfWork
                .reservationRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false, "Table", "TimeInterval");

            var Result = new Paginate<Reservation>();
            Result.Items = reservations;
            Result.CurrentPage = page;
            Result.AllPageCount = await getPageCount(10);
            return Result;
        }

        public async Task<Paginate<Reservation>> GetAllPaginatedAsync(int page, DateTime date)
        {
            var reservations = await _unitOfWork
                .reservationRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false && p.ReservDate.Date == date, "Table",
                    "TimeInterval");

            var Result = new Paginate<Reservation>();
            Result.Items = reservations;
            Result.CurrentPage = page;
            Result.AllPageCount = await getPageCount(10);
            return Result;
        }

        public async Task<Reservation> GetAsync(int id)
        {
            return await _unitOfWork.reservationRepository.GetAsync(p => p.IsDeleted == false && p.Id == id, "Table",
                "TimeInterval");
        }

        public async Task Create(ReservationPostVM reservationPostVm)
        {
            var time = (await _unitOfWork
                .ITimeIntervalRepository
                .GetAsync(p => p.Id == reservationPostVm.TimeIntervalIdId)).Time;
            var newReserv = new Reservation()
            {
                Name = reservationPostVm.Name,
                LastName = reservationPostVm.LastName,
                PhoneNumber = reservationPostVm.PhoneNumber,
                Email = reservationPostVm.Email,
                ReservDate = reservationPostVm.ReservDate,
                TableID = reservationPostVm.TableID,
                TimeIntervalId = reservationPostVm.TimeIntervalIdId,
                ReservEndDate = reservationPostVm.ReservDate.AddHours(time)
            };
            if (reservationPostVm.Additionals is null)
            {
                newReserv.Additionals = " ";
            }
            else
            {
                newReserv.Additionals = reservationPostVm.Additionals;
            }

            await _unitOfWork.reservationRepository.CreateAsync(newReserv);
            await _unitOfWork.SaveAsync();
        }

        public Task Update(int id, ReservationPostVM reservationPostVm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsReserved(DateTime startDateTime, DateTime EndDateTime, int tableId)
        {
            //var table = await _unitOfWork.tableRepository.GetWithRezervsAsync(tableId);
            var table = await _unitOfWork.tableRepository.GetAsync(p => p.IsDeleted == false && p.Id == tableId,
                "Reservations");
            if (table.Reservations.Count == 0) return false;
            var reservs = table.Reservations.Where(p => p.IsDeleted == false);

            foreach (var reserv in reservs)
            {
                if (reserv.ReservDate<EndDateTime && reserv.ReservEndDate>startDateTime)
                {
                    return true;
                }
                if (reserv.ReservDate>=EndDateTime || reserv.ReservEndDate<=startDateTime)
                {
                    //25-3-2022  14:00 - 16:00 ****
                    //25-3-2022  17:00 - 18:00
                    //25-3-2022  11:00 - 12:00
                    //25-3-2022  11:00 - 15:00
                    //25-3-2022  11:00 - 18:00
                    
                    return false;

                    
                    
                }
            }

            return true;

            // if (table.Reservations.Where(p => p.ReservDate.Date == dateTime.Date && p.IsDeleted == false)
            //         .FirstOrDefault() != null)
            // {
            //     return true;
            // }


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


        public async Task Remove(int id)
        {
            var rezerv = await _unitOfWork
                .reservationRepository
                .GetAsync(p => p.Id == id);
            if (rezerv != null)
            {
                rezerv.IsDeleted = true;
                _unitOfWork.reservationRepository.Update(rezerv);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<int> getPageCount(int take)
        {
            var reservations = await _unitOfWork
                .reservationRepository
                .GetAllAsync(p => p.IsDeleted == false);
            var productCount = reservations.Count;
            return (int) Math.Ceiling(((decimal) productCount / take));
        }

        public async Task<int> getLastIdAsync()
        {
            var reserv = await _unitOfWork.reservationRepository
                .GetAllAsync(p => p.IsDeleted == false);
            return reserv[reserv.Count - 1].Id;
        }

        public async Task ConfirmReservation(int id)
        {
            var reservation = await _unitOfWork.reservationRepository.GetAsync(p => p.Id == id);
            reservation.IsActive = true;
            _unitOfWork.reservationRepository.Update(reservation);
            await _unitOfWork.SaveAsync();
        }
    }
}