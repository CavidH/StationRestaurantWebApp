using Business.ViewModels.User;
using FluentValidation;

namespace Business.Validators.User
{
    public class UserPostVMValidator:AbstractValidator<UserPostVM>
    {
        public UserPostVMValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(90);
            RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(90);
            RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(120);
            RuleFor(p => p.UserName).NotNull().NotEmpty().MaximumLength(90);
            RuleFor(p => p.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(90);
            RuleFor(p => p.ConfirmPassword).NotNull().NotEmpty().MinimumLength(8).MaximumLength(90).Equal(p=>p.Password);
            
            
        }
    }
}