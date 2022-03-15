namespace Business.Interfaces
{
    public interface IUnitOfWorkService
    {
        public IHeadSlideService headSlideService { get; }
        public IProductService productService { get; }
        public IProductCategoryService productCategoryService { get; }
        public IReservationService reservationService { get; }
        public ITableService tableService { get; }
        public IUserService userService { get; }
        public IGalleryService galleryService { get; }
    }
}