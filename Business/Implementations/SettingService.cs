using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities;
using Business.Utilities.Helpers;
using Business.ViewModels.Setting;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Business.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private string _erorrMessage;


        public SettingService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await _unitOfWork.SettingRepository.GetAllAsync();
        }

        public async Task<Dictionary<string, string>> GetAllAsynDic()
        {
            var dbSetting = await _unitOfWork.SettingRepository.GetAllAsync();
            return dbSetting.ToDictionary(p => p.Key, p => p.Value);
        }

        public async Task<Setting> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create()
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(int id, SettingVM settingVm)
        {
            if (!settingVm.ImageFile.CheckFileType("image/"))
            {
                _erorrMessage = $"{settingVm.ImageFile.FileName} must be  image type ";
                throw new ImageFileException(_erorrMessage);
            }

            if (!settingVm.ImageFile.CheckFileSize(300))
            {
                _erorrMessage = $"{settingVm.ImageFile.FileName} size must be less than 300kb";
                throw new ImageFileException(_erorrMessage);
            }

            var setting = await _unitOfWork
                .SettingRepository
                .GetAsync(p => p.Id == id);

            if (setting is null)
            {
                throw new NotFoundException("Setting Not Found");
            }

            FileHelper.RemoveFile(_environment.WebRootPath, setting.Value, "Assets", "img");
            string imageFile = await settingVm.ImageFile.SaveFileAsync(_environment.WebRootPath, "Assets", "img");
            setting.UpdatedAt = DateTime.Now;
            setting.Value = imageFile;
            _unitOfWork.SettingRepository.Update(setting);

            await _unitOfWork.SaveAsync();
        }
    }
}