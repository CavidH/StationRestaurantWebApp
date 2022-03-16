using Business.ViewModels.Comment;
using FluentValidation;

namespace Business.Validators.Comment
{
    public class CommentVMValidator : AbstractValidator<CommentVM>
    {
        public CommentVMValidator()
        {
            RuleFor(p => p.FullName).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(200);
            RuleFor(p => p.Subject).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.CommentContent).NotNull().NotEmpty().MaximumLength(500);
        }
    }
}