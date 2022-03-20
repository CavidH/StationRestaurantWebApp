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
        public ICommentService commentService { get; }
        public IContactService contactService { get; }
        public ISettingService settingService { get; }
        public IAboutService aboutService { get; }
        public IMessageService messageService { get; }
        public ITimeIntervalService timeIntervalService { get; }
    }
}