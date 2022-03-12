using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class HeadSlideRepository : Repository<HeadSlide>, IHeadSlideRepository
    {
        private readonly AppDbContext _context;

        public HeadSlideRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
