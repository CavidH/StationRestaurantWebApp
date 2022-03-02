using System.Threading.Tasks;
using Core.Interfaces;

namespace Core
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        public IProductCategoryRepository productCategoryRepository { get; }
        Task SaveAsync();
    }
}
