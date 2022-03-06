using FluentValidation;

namespace Business.Validators.Table
{
    public class TablePostVMValidator:AbstractValidator<Core.Entities.Table>
    {
        public TablePostVMValidator()
        {
            RuleFor(p => p.TableNumber)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
              RuleFor(p => p.MaxPersonCount)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            
        }
        
    }
}