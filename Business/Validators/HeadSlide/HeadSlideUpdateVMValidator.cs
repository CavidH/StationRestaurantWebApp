using Business.ViewModels.HeadSlide;
using FluentValidation;

namespace Business.Validators.HeadSlide
{
    public class HeadsSlideUpdateVMValidator : AbstractValidator<HeadSlideUpdateVM>
    {
        public HeadsSlideUpdateVMValidator()
        {
            RuleFor(p => p.ImageFile).NotNull().NotEmpty();
        }
    }
}