using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Business.ViewModels.Reservation;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Paginate<Reservation>> GetAllPaginatedAsync(int page);
        Task<Reservation> GetAsync(int id);
        Task Create(ReservationPostVM reservationPostVm);
        Task Update(int id, ReservationPostVM reservationPostVm);
        Task<bool> IsReserved(DateTime dateTime, int tableId);
        Task Remove(int id);
        Task<int> getPageCount(int Take);
    }
}