using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels.Setting;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllAsync();
        Task<Dictionary<string, string>> GetAllAsynDic();

        Task<Setting> GetAsync(int id);
        Task Create();
        Task Update(int id, SettingVM settingVm);
    }
}