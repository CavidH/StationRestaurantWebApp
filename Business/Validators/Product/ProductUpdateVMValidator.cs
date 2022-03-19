using Business.ViewModels.ProductVM;
using FluentValidation;

namespace Business.Validators.Product
{
    public class ProductUpdateVMValidator : AbstractValidator<ProductUpdateVM>
    {
        public ProductUpdateVMValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.Title).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.Description).NotNull().NotEmpty().MaximumLength(750);
            RuleFor(p => p.Price).NotNull().NotEmpty().GreaterThanOrEqualTo(0);

        }
    }
}