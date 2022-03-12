using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities;
using Business.ViewModels.HeadSlide;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Implementations
{
    public class HeadSlideService : IHeadSlideService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _env { get; }
        private string _erorrMessage;

        public HeadSlideService(IUnitOfWork unitOfWork,IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task<List<HeadSlide>> GetAllAsync()
        {
           var headSlides = await _unitOfWork.headSlideRepository.GetAllAsync();
           return headSlides;
        }

        public async Task<HeadSlide> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(HeadSlidePostVM headSlidePostVm)
        {
            int EmptySlide =await _unitOfWork.headSlideRepository.GetEmptySliderCount();

            if (headSlidePostVm.ImageFile.Count > EmptySlide)
            { 
                throw new SlideOutOfBoundException($"You can currently upload {EmptySlide} slides  ** Max Limit 8 slide");
            }
            
            if (!ChechkImageValid(headSlidePostVm.ImageFile))
            {
                throw new ImageFileException(_erorrMessage);
            }
            
            foreach (var photo in headSlidePostVm.ImageFile)
            {
                string filename = await photo.SaveFileAsync(_env.WebRootPath, "Assets", "img");
                await _unitOfWork.headSlideRepository.CreateAsync(new HeadSlide {Image = filename});
                await _unitOfWork.SaveAsync();
            }
        }
        private bool ChechkImageValid(List<IFormFile> photos)
        {
            foreach (var photo in photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    _erorrMessage = $"{photo.FileName} must be  image type ";
                    return false;
                }

                if (!photo.CheckFileSize(300))
                {
                    _erorrMessage = $"{photo.FileName} size must be less than 300kb";
                    return false;
                }
            }

            return true;
        }


        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}