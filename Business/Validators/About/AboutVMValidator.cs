using Business.ViewModels;
using Business.ViewModels.About;
using FluentValidation;

namespace Business.Validators.About
{
    public class AboutVMValidator : AbstractValidator<AboutVM>
    {
        public AboutVMValidator()
        {
            RuleFor(p => p.Title).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.Head).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.Content).NotNull().NotEmpty().MaximumLength(600);
        }
    }
}