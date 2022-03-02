
namespace Core.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int MaxPersonCount { get; set; }   
        public bool IsReserved { get; set; }  
        public bool IsDeleted { get; set; }



        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
