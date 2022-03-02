using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Reservation
    {
        public int  Id { get; set; }
        public string Name  { get; set; }
        public string LastName  { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Additionals { get; set; }



        public DateTime ReservDate { get; set; }
        public bool IsActive { get; set; }




        public int TableID { get; set; }
        public Table Table { get; set; }

    }
}
