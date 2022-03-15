using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class GalleryImageRepository : Repository<GaleryImage>, IGalleryImageRepository
    {
        private readonly AppDbContext _context;

        public GalleryImageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}