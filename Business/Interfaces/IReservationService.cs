using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels;
using Business.ViewModels.ProductVM;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Paginate<Reservation>> GetAllPaginatedAsync(int page);
        Task<Reservation> GetAsync(int id);
        Task Create(ProductPostVM productPostVm);
        Task Update(int id, ProductUpdateVM productUpdateVm);
        Task Remove(int id);
    }
}
