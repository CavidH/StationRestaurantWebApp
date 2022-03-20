using Business.ViewModels.Contact;
using FluentValidation;

namespace Business.Validators.Contact
{
    public class ContactVMValidator : AbstractValidator<ContactVM>
    {
        public ContactVMValidator()
        {
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(200);
            RuleFor(p => p.PhoneNumber).NotNull().NotEmpty().Matches(@"^(\+|\d)[0-9]{8,16}$").MaximumLength(13);
            RuleFor(p => p.Message).NotNull().NotEmpty().MaximumLength(500);
        }
    }
}