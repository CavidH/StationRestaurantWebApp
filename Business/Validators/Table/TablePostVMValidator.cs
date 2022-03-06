using Business.ViewModels.Table;
using FluentValidation;

namespace Business.Validators.Table
{
    public class TablePostVMValidator:AbstractValidator<TablePostVM>
    {
        public TablePostVMValidator()
        {
            RuleFor(p => p.TableNumber)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(0, 100);
            RuleFor(p => p.MaxPersonCount)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(0, 100);

        }
        
    }
}