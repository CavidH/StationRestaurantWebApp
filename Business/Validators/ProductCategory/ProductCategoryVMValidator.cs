using Business.ViewModels.ProductCategory;
using FluentValidation;

namespace Business.Validators.ProductCategory
{
    public class ProductCategoryVMValidator : AbstractValidator<ProductCategoryVM>
    {
        public ProductCategoryVMValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}