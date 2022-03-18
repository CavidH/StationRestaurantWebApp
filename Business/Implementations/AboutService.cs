using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities;
using Business.Utilities.Helpers;
using Business.ViewModels.About;
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
            return (await _unitOfWork.aboutRepository.GetAllAsync()).FirstOrDefault();
        }


        public async Task Update(AboutVM aboutVm)
        {
            var about = (await _unitOfWork.aboutRepository.GetAllAsync()).FirstOrDefault();

            about.Title = aboutVm.Title;
            about.Content = aboutVm.Content;
            about.Head = aboutVm.Head;
            about.UpdatedAt = DateTime.Now;
            if (aboutVm.ImageFile != null)
            {
                if (!aboutVm.ImageFile.CheckFileType("image/"))
                {
                    _erorrMessage = $"{aboutVm.ImageFile.FileName} must be  image type ";
                    throw new ImageFileException(_erorrMessage);
                }

                if (!aboutVm.ImageFile.CheckFileSize(300))
                {
                    _erorrMessage = $"{aboutVm.ImageFile.FileName} size must be less than 300kb";
                    throw new ImageFileException(_erorrMessage);
                }

                FileHelper.RemoveFile(_environment.WebRootPath, about.Image, "Assets", "img");
                string imageFile = await aboutVm.ImageFile.SaveFileAsync(_environment.WebRootPath, "Assets", "img");
                about.Image = imageFile;
            }

            _unitOfWork.aboutRepository.Update(about);
            await _unitOfWork.SaveAsync();
        }
    }
}