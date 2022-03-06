using Core.Entities;
using Core.Interfaces;
using Data.DAL;

namespace Data.Repositories.Implementations
{
    public class TableRepository:Repository<Table>,ITableRepository
    {
        private readonly AppDbContext _context;

        public TableRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
