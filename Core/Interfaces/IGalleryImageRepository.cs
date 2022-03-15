using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGalleryImageRepository :IRepository<GaleryImage>
    {
        Task<List<GaleryImage>> GetLastProduct(int take);
    }
}