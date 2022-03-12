namespace Business.Interfaces
{
    public interface IUnitOfWorkService
    {
        public IHeadSlideService headSlideService { get; }
        public IProductService productService { get; }
    }
}