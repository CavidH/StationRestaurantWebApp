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
            var contacts = await _unitOfWork
                .contactRepository
                .GetAllPaginatedAsync(page, 10, p => p.IsDeleted == false);

            var Result = new Paginate<Contact>();
            Result.Items = contacts;
            Result.CurrentPage = page;
            Result.AllPageCount = await getPageCount(10);
            return Result;
        }

        public async Task<Contact> GetAsync(int id)
        {
            var contact = await _unitOfWork.contactRepository.GetAsync(p => p.IsDeleted == false);
            if (contact is null) throw new Exception("Contact  Not Found ");
            return contact;
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
            var contact = await _unitOfWork
                .contactRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
            contact.IsDeleted = true;
            _unitOfWork.contactRepository.Update(contact);
            await _unitOfWork.SaveAsync();
        }

        public async Task<int> getPageCount(int take)
        {
            var contacts = await _unitOfWork
                .contactRepository
                .GetAllAsync(p => p.IsDeleted == false);
            var contactsCount = contacts.Count;
            return (int) Math.Ceiling(((decimal) contactsCount / take));
        }
    }
}