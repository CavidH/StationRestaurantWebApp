using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Core.Entities;

namespace Business.Implementations
{
    public class ContactService:IContactService
    {
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

        public async Task Create(Contact contact)
        {
            throw new System.NotImplementedException();
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