using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class TimeIntervalRepositoryRepository:Repository<Timeİnterval>,ITimeİntervalRepository
    {
        private readonly AppDbContext _context;

        public TimeIntervalRepositoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}