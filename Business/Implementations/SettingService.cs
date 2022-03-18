using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class SettingService:ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Setting>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Setting> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create()
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}