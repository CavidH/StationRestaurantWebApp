using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllAsync();
        Task<Setting> GetAsync(int id);
        Task Create();
        Task Update(int id);
    }
}