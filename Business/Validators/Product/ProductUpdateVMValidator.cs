using Business.ViewModels.ProductVM;
using FluentValidation;

namespace Business.Validators.Product
{
    public class ProductUpdateVMValidator:AbstractValidator<ProductUpdateVM>
    {
        public ProductUpdateVMValidator()
        {
            RuleFor(p => p.Name).MaximumLength(200);
            RuleFor(p => p.Title).MaximumLength(250);
            RuleFor(p => p.Description).MaximumLength(500);
        }
    }
}