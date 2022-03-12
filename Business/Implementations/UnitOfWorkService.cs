using Business.Interfaces;
using Core;
using Microsoft.AspNetCore.Hosting;

namespace Business.Implementations
{
    public class UnitOfWorkService:IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private  IProductService _productService;
        private IHeadSlideService _headSlideService;


        public UnitOfWorkService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }
        // private IHeadSlideService headSlideService { get; }


        public IHeadSlideService headSlideService =>
            _headSlideService = _headSlideService ?? new HeadSlideService(_unitOfWork, _environment);
        public IProductService productService => _productService = _productService ?? new ProductService(_unitOfWork,_environment);
    }
}