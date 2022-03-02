using Business.ViewModels.ProductCategoryVM;
using FluentValidation;

namespace Business.Validators.ProductCategory
{
    public class ProductCategoryPostVMValidator : AbstractValidator<ProductCategoryPostVM>
    {
        public ProductCategoryPostVMValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}