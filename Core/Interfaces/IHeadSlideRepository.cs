using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IHeadSlideRepository:IRepository<HeadSlide>
    {
       Task<int> GetEmptySliderCount();
    }
}
