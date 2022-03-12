using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels;
using Business.ViewModels.User;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllAsync();
        Task<Paginate<ApplicationUser>> GetAllPaginatedAsync(int page);
        Task Login(UserLoginVM userLoginVm);
        Task LogOut();
        Task<ApplicationUser> GetAsync(int id);
        Task Create(UserPostVM userPostVM);
        Task Update(int id, UserPostVM userPostVM);
        Task Remove(int id);
        Task<int> getPageCount(int take);
    }
}