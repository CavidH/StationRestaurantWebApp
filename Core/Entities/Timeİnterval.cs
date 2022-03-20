using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

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
