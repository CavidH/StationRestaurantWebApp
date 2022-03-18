using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly AppDbContext _context;

        public SettingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}