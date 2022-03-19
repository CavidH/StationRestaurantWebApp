using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities;
using Business.Utilities.Helpers;
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

        public async Task<List<GaleryImage>> GetLastimageAsync()
        {
            return await _unitOfWork
                .galleryImageRepository
                .GetLastProduct(3);
        }

        public async Task<List<GaleryImage>> GetAllAsync()
        {
            return await _unitOfWork.galleryImageRepository.GetAllAsync();
        }

        public async Task<Paginate<GaleryImage>> GetAllPaginatedAsync(int page, int size)
        {
            var dbGalleryImages = await _unitOfWork
                .galleryImageRepository
                .GetAllPaginatedAsync(page, size);

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
            if (!galleryUpdateVm.ImagFile.CheckFileType("image/"))
            {
                _erorrMessage = $"{galleryUpdateVm.ImagFile.FileName} must be  image type ";
                throw new ImageFileException(_erorrMessage);
            }

            if (!galleryUpdateVm.ImagFile.CheckFileSize(300))
            {
                _erorrMessage = $"{galleryUpdateVm.ImagFile.FileName} size must be less than 300kb";
                throw new ImageFileException(_erorrMessage);
            }

            var galeryImage = await _unitOfWork.galleryImageRepository.GetAsync(p => p.Id == id);
            if (galleryUpdateVm.ImagFile is null) throw new NotFoundException("Image not found");
            FileHelper.RemoveFile(_environment.WebRootPath, galeryImage.Image, "Assets", "img");
            var filename = galleryUpdateVm.ImagFile.SaveFileAsync(_environment.WebRootPath, "Assets", "img");
            filename.Wait();
            galeryImage.Image = await filename;
            _unitOfWork.galleryImageRepository.Update(galeryImage);
            await _unitOfWork.SaveAsync();
        }

        public async Task Remove(int id)
        {
            var galleryImage = await _unitOfWork.galleryImageRepository.GetAsync(p => p.Id == id);
            if (galleryImage == null) throw new NotFoundException("Slide not found");
            FileHelper.RemoveFile(_environment.WebRootPath, galleryImage.Image, "Assets", "img");
            _unitOfWork.galleryImageRepository.Remove(galleryImage);
            await _unitOfWork.SaveAsync();
        }

        public async Task<int> getPageCount(int take)
        {
            var galleryImages = await _unitOfWork
                .galleryImageRepository
                .GetAllAsync();
            var galleryImagesCount = galleryImages.Count;
            return (int) Math.Ceiling(((decimal) galleryImagesCount / take));
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