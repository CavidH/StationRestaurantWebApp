using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels.HeadSlide;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IHeadSlideService
    {
        Task<List<HeadSlide>> GetAllAsync();
        Task<HeadSlide> GetAsync(int id);
        Task Create(HeadSlidePostVM headSlidePostVm);
        //Task Update(int id);
        Task Remove(int id);
        //Task<int> getPageCount(int take);
        //Task<bool> IsExist(int TableNumber);
    }
}
