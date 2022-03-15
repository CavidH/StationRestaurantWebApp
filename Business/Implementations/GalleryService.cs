using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities;
using Business.ViewModels;
using Business.ViewModels.Gallery;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Implementations
{
    public class GalleryService : IGalleryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _environment { get; }
        private string _erorrMessage;

        public GalleryService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task<List<GaleryImage>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<GaleryImage>> GetLastProductsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Paginate<GaleryImage>> GetAllPaginatedAsync(int page)
        {
            var dbGalleryImages = await _unitOfWork
                .galleryImageRepository
                .GetAllPaginatedAsync(page, 10);

            var Result = new Paginate<GaleryImage>();
            Result.Items = dbGalleryImages;
            Result.CurrentPage = page;
            Result.AllPageCount = await getPageCount(10);
            return Result;
        }

        public async Task<GaleryImage> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create(GalleryPostVM galleryPostVm)
        {
            if (!ChechkImageValid(galleryPostVm.ImageFiles))
            {
                throw new ImageFileException(_erorrMessage);
            }

            foreach (var photo in galleryPostVm.ImageFiles)
            {
                string filename = await photo.SaveFileAsync(_environment.WebRootPath, "Assets", "img");
                await _unitOfWork.galleryImageRepository.CreateAsync(new GaleryImage {Image = filename});
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task Update(int id, GalleryUpdateVM galleryUpdateVm)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> getPageCount(int take)
        {
            throw new System.NotImplementedException();
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
    }
}