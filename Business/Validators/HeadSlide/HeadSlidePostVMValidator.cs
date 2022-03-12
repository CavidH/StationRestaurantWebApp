using Business.ViewModels.HeadSlide;
using FluentValidation;

namespace Business.Validators.HeadSlide
{
    public class HeadSlidePostVMValidator : AbstractValidator<HeadSlidePostVM>
    {
        public HeadSlidePostVMValidator()
        {
            RuleFor(p => p.FormFiles).NotEmpty().NotNull();
        }
    }
}
