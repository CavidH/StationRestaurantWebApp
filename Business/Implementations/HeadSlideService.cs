using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.HeadSlide;
using Core.Entities;

namespace Business.Implementations
{
    public class HeadSlideService:IHeadSlideService
    {
        public async Task<List<HeadSlide>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HeadSlide> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(HeadSlidePostVM headSlidePostVm)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
