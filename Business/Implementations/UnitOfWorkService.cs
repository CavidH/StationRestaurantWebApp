using Business.Interfaces;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Business.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IProductService _productService;
        private IHeadSlideService _headSlideService;
        private IProductCategoryService _productCategoryService;
        private IReservationService _reservationService;
        private ITableService _tableService;
        private IUserService _userService;
        private IGalleryService _galleryService;
        private ICommentService _commentService;
        private IContactService _contactService;
        private ISettingService _settingService;


        public UnitOfWorkService(IUnitOfWork unitOfWork, IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        // private IHeadSlideService headSlideService { get; }


        public IHeadSlideService headSlideService =>
            _headSlideService = _headSlideService ?? new HeadSlideService(_unitOfWork, _environment);

        public IProductService productService =>
            _productService = _productService ?? new ProductService(_unitOfWork, _environment);

        public IProductCategoryService productCategoryService => _productCategoryService =
            _productCategoryService ?? new ProductCategoryService(_unitOfWork);

        public IReservationService reservationService =>
            _reservationService = _reservationService ?? new RezervationService(_unitOfWork);

        public ITableService tableService =>
            _tableService = _tableService ?? new TableService(_unitOfWork);

        public IUserService userService => _userService =
            _userService = _userService ?? new UserService(_userManager, _signInManager, _roleManager);

        public IGalleryService galleryService =>
            _galleryService = _galleryService ?? new GalleryService(_unitOfWork, _environment);

        public ICommentService commentService =>
            _commentService = _commentService ?? new CommentService(_unitOfWork);

        public IContactService contactService =>
            _contactService = _contactService ?? new ContactService(_unitOfWork);

        public ISettingService settingService =>
            _settingService = _settingService ?? new SettingService(_unitOfWork);
    }
}