using System.Threading.Tasks;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get;}
        Task SaveAsync();
    }
}
