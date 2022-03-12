using System.Threading.Tasks;
using Core.Interfaces;

namespace Core
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        public IProductCategoryRepository productCategoryRepository { get; }
        public ITableRepository tableRepository { get; }
        public IReservationRepository reservationRepository { get; }
        public IHeadSlideRepository headSlideRepository { get; }

        Task SaveAsync();
    }
}
