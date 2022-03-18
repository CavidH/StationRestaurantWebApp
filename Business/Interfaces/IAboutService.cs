using System.Threading.Tasks;
using Business.ViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IAboutService
    {
        Task<About> GetAsync();
        Task Update(AboutVM aboutVm);
    }
}