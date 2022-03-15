using Business.ViewModels.Gallery;
using FluentValidation;

namespace Business.Validators.Gallery
{
    public class GalleryUpdateVMValidator : AbstractValidator<GalleryUpdateVM>
    {
        public GalleryUpdateVMValidator()
        {
            RuleFor(p => p.ImagFile)
                .NotNull()
                .NotEmpty();
        }
    }
}