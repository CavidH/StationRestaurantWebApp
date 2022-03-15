using Business.ViewModels.Gallery;
using FluentValidation;

namespace Business.Validators.Gallery
{
    public class GalleryVMValidator : AbstractValidator<GalleryPostVM>
    {
        public GalleryVMValidator()
        {
            RuleFor(p => p.ImageFiles)
                .NotNull()
                .NotEmpty();
        }
    }
}