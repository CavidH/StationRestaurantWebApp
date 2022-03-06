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
    public class RezervationService:IReservationService
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

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
