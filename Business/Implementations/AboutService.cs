using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Business.Implementations
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private string _erorrMessage;


        public AboutService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task<About> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(AboutVM aboutVm)
        {
            throw new System.NotImplementedException();
        }
    }
}