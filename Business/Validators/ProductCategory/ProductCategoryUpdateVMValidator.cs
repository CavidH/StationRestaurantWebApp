using Business.ViewModels.ProductCategoryVM;
using FluentValidation;

namespace Business.Validators.ProductCategory
{
    public class ProductCategoryUpdateVMValidator:AbstractValidator<ProductCategoryUpdateVM>
    {
        public ProductCategoryUpdateVMValidator()
        {
            // RuleFor(p=>p.)
        }
    }
}