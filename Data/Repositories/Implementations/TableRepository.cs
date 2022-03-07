using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        private readonly AppDbContext _context;

        public TableRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Table>> GetAllWithRezervsAsync()
        {
            return await _context
                .Tables
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Reservations)
                .ToListAsync();
        }

        public async Task<Table> GetWithRezervsAsync(int id)
        {
            return await _context
                .Tables
                .Where(p => p.IsDeleted == false && p.Id == id)
                .Include(p => p.Reservations).FirstOrDefaultAsync();
        }
    }
}