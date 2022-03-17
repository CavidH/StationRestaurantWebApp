using FluentValidation;

namespace Business.Validators.Contact
{
    public class ContactVMValidator : AbstractValidator<Core.Entities.Contact>
    {
        public ContactVMValidator()
        {
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(200);
            RuleFor(p => p.PhoneNumber).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(p => p.Message).NotNull().NotEmpty().MaximumLength(500);
        }
    }
}