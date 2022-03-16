using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class ContactRepository:Repository<Contact>,IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}