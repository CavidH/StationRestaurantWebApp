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
        Task<List<Reservation>> GetAllStatAsync();
        Task<Paginate<Reservation>> GetAllPaginatedAsync(int page);
        Task<Paginate<Reservation>> GetAllPaginatedAsync(int page, DateTime date);
        Task<Reservation> GetAsync(int id);
        Task Create(ReservationPostVM reservationPostVm);
        Task Update(int id, ReservationPostVM reservationPostVm);
        Task<bool> IsReserved(DateTime startDateTime,DateTime EndDateTime, int tableId);
        Task Remove(int id);
        Task<int> getPageCount(int Take);
        Task<int> getLastIdAsync();
        Task ConfirmReservation(int id);
    }
}