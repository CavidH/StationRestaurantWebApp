using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        private readonly AppDbContext _context;

        public AboutRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}