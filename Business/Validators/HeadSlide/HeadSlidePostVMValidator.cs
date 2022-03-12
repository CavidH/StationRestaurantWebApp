using Business.ViewModels.HeadSlide;
using FluentValidation;

namespace Business.Validators.HeadSlide
{
    public class HeadSlidePostVMValidator : AbstractValidator<HeadSlidePostVM>
    {
        public HeadSlidePostVMValidator()
        {
            RuleFor(p => p.ImageFile).NotEmpty().NotNull();
        }
    }
}
