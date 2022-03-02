using Business.ViewModels.ProductVM;
using FluentValidation;

namespace Business.Validators.Product
{
    public  class ProductPostVMValidator:AbstractValidator<ProductPostVM>
    {
        public ProductPostVMValidator()
        {
            //RuleFor(p=>p.name)
        }
    }
}
