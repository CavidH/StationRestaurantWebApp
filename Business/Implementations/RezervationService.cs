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
using Microsoft.EntityFrameworkCore;

namespace Business.Implementations
{
    public class RezervationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;

        public RezervationService(IUnitOfWork unitOfWork,AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
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

        public async Task<List<Table>> CheckRezervDate(DateTime dateTime)
        {
            // var allDbTables = await _unitOfWork
            //     .tableRepository
            //     .GetAllAsync(p=>p.IsDeleted==false,"Reservations");
            var allDbTables = await _context.Tables.Include(p=>p.Reservations).ToListAsync();
            var emptyTables = new List<Table>();
            // foreach (var table in allDbTables)
            // {
            //     foreach (var rezerv in table.Reservations)
            //     {
            //         // rezerv.ReservDate.Date == dateTime.Date
            //     }
            // }

            for (int i = 0; i < allDbTables.Count; i++)
            {
                var rezev = allDbTables[i].Reservations.Where(p => p.ReservDate.Date == dateTime.Date).ToList();
                if (rezev.Count==0)
                {
                    emptyTables.Add(allDbTables[i]);
                }
            }

            return emptyTables;
        }


        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}