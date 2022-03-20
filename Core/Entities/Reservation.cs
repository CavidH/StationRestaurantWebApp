using System;


namespace Core.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Additionals { get; set; }
        public DateTime ReservDate { get; set; }
        public DateTime ReservEndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int TimeIntervalId { get; set; }
        public Timeİnterval TimeInterval { get; set; }

        public int TableID { get; set; }
        public Table Table { get; set; }

    }
}
