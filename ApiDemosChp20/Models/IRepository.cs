using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemosChp20.Models
{
    public interface IRepository
    {
         IEnumerable<Reservation> GetAllReservations(); 
        //AllReservations GetAllReservations();
        Reservation GetReservation(int reservationId);
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        bool DeleteReservation(int reservationId);
    }
}
