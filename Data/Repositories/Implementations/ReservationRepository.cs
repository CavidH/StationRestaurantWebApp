using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GettAllWithTable()
        {
            var reservations = await _context
                .Reservations
                .Where(p => p.IsDeleted == false)
                .ToListAsync();
            return reservations;
        }
    }
}