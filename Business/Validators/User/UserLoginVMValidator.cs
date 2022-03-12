using Business.ViewModels.User;
using FluentValidation;

namespace Business.Validators.User
{
    public class UserLoginVMValidator : AbstractValidator<UserLoginVM>
    {
        public UserLoginVMValidator()
        {
            RuleFor(p => p.EMail).NotNull().NotEmpty().EmailAddress().MaximumLength(120);
            RuleFor(p => p.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(120);
        }
    }
}