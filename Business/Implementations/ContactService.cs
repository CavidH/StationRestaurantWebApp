using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.Contact;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Paginate<Contact>> GetAllPaginatedAsync(int page)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contact> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create(ContactVM contactVm)
        {
            var contact = new Contact
            {
                FirstName = contactVm.FirstName,
                LastName = contactVm.LastName,
                Email = contactVm.Email,
                Message = contactVm.Message,
                PhoneNumber = contactVm.PhoneNumber,
                CreatedAt = DateTime.Now
            };
            await _unitOfWork.contactRepository.CreateAsync(contact);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, Contact contact)
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
    }
}