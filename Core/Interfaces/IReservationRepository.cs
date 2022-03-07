using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IReservationRepository:IRepository<Reservation>
    {
        Task<List<Reservation>> GettAllWithTable();
    }
}
