using System;
using Business.ViewModels.Reservation;
using FluentValidation;

namespace Business.Validators.Reservation
{
    public class ReservationPostVMValidator : AbstractValidator<ReservationPostVM>
    {
        public ReservationPostVMValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.PhoneNumber).NotNull().NotEmpty().Matches(@"^(\+|\d)[0-9]{8,16}$").MaximumLength(200);
            RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(200);
            RuleFor(p => p.Additionals).MaximumLength(300);
            RuleFor(p => p.ReservDate).NotNull().NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(p => p.TableID).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}