using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels;
using Business.ViewModels.Contact;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
        Task<Paginate<Contact>> GetAllPaginatedAsync(int page);
        Task<Contact> GetAsync(int id);
        Task Create(ContactVM contactVM);
        Task Update(int id, Contact contact);
        Task Remove(int id);
        Task<int> getPageCount(int take);
    }
}