using System.Collections.Generic; 

namespace Core.Entities
{
    public class Timeİnterval
    {
        public int Id { get; set; }
        public double Time { get; set; }
        public bool IsDeleted { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
