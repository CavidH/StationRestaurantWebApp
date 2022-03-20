using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Core;
using Core.Entities;


namespace Business.Implementations
{
    public class TimeIntervalService : ITimeIntervalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeIntervalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Timeİnterval>> GetAllAsync()
        {
            return await _unitOfWork.ITimeIntervalRepository.GetAllAsync(p => p.IsDeleted == false);
        }

        public async Task<Timeİnterval> GetAsync(int id)
        {
            return await _unitOfWork.ITimeIntervalRepository.GetAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task Create(Timeİnterval timeInterval)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(int id, Timeİnterval timeInterval)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}