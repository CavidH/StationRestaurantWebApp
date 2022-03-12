using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public class HeadSlideRepository : Repository<HeadSlide>, IHeadSlideRepository
    {
        private readonly AppDbContext _context;

        public HeadSlideRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<int> GetEmptySliderCount()
        {
            return 7 - await _context.HeadSlides.CountAsync();
        }
    }
}