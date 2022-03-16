using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Data.DAL;
using Data.Repositories.Implementations;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IProductRepository _productRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private ITableRepository _tableRepository;
        private IReservationRepository _reservationRepository;
        private IHeadSlideRepository _headSlideRepository;
        private IGalleryImageRepository _galleryImageRepository;
        private ICommentRepository _commentRepository;
        private IContactRepository _contactRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository productRepository =>
            _productRepository = _productRepository ?? new ProductRepository(_context);

        public IProductCategoryRepository productCategoryRepository => _productCategoryRepository =
            _productCategoryRepository ?? new ProductCategoryRepository(_context);

        public ITableRepository tableRepository => _tableRepository = _tableRepository ?? new TableRepository(_context);

        public IReservationRepository reservationRepository =>
            _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);

        public IHeadSlideRepository headSlideRepository =>
            _headSlideRepository = _headSlideRepository ?? new HeadSlideRepository(_context);

        public IGalleryImageRepository galleryImageRepository =>
            _galleryImageRepository = _galleryImageRepository ?? new GalleryImageRepository(_context);

        public ICommentRepository commentRepository =>
            _commentRepository = _commentRepository ?? new CommentRepository(_context);

        public IContactRepository contactRepository =>
            _contactRepository = _contactRepository ?? new ContactRepository(_context);


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}