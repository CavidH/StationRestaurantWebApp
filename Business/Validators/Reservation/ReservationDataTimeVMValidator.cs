using System;
using Business.ViewModels.Reservation;
using FluentValidation;

namespace Business.Validators.Reservation
{
    public class ReservationDataTimeVMValidator:AbstractValidator<ReservationDataTimeVM>
    {
        public ReservationDataTimeVMValidator()
        { 
            RuleFor(p => p.ReservDate).NotNull().NotEmpty().GreaterThan(DateTime.Now);
        }
        
    }
}