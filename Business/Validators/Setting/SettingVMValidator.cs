using Business.ViewModels.Setting;
using FluentValidation;

namespace Business.Validators.Setting
{
    public class SettingVMValidator : AbstractValidator<SettingVM>
    {
        public SettingVMValidator()
        {
            RuleFor(p => p.ImageFile)
                .NotNull()
                .NotEmpty();
        }
    }
}