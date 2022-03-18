using Business.ViewModels.Reply;
using FluentValidation;

namespace Business.Validators.Reply
{
    public class ReplyVMValidator : AbstractValidator<ReplyVM>
    {
        public ReplyVMValidator()
        {
            RuleFor(p => p.Message)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}