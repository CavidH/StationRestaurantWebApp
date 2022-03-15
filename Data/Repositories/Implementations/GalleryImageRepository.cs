using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public class GalleryImageRepository : Repository<GaleryImage>, IGalleryImageRepository
    {
        private readonly AppDbContext _context;

        public GalleryImageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GaleryImage>> GetLastProduct(int take)
        {
            return await _context
                .GaleryImages
                .OrderByDescending(p => p.Id)
                .Take(take)
                .ToListAsync();
        }
    }
}