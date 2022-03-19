using Business.ViewModels.Message;
using FluentValidation;

namespace Business.Validators.Message
{
    public class MessageVMValidator : AbstractValidator<MessageVM>
    {
        public MessageVMValidator()
        {
            RuleFor(p => p.Msg).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(p => p.Subject).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}