using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Implementations;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ITimeIntervalService
    {
        Task<List<Timeİnterval>> GetAllAsync();
        Task<Timeİnterval> GetAsync(int id);
        Task Create(Timeİnterval timeInterval);
        Task Update(int id, Timeİnterval timeInterval);
        Task Remove(int id);
    }
}