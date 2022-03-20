using System;

namespace Business.ViewModels.Reservation
{
    public class ReservationPostVM
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Additionals { get; set; }
        public DateTime ReservDate { get; set; }
        public int TableID { get; set; }
        public int TimeIntervalIdId { get; set; }

    }
}