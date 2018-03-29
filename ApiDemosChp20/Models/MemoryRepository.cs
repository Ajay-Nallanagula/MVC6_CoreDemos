using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Data.OData.Query.SemanticAst;

namespace ApiDemosChp20.Models
{
    public class MemoryRepository : IRepository
    {
        public MemoryRepository()
        {
            ReservationDict = new Dictionary<int, Reservation>();
           var reservationSampleList = new List<Reservation>
            {
                new Reservation {ClientName = "Amazon Portal", Location = "Amazon HQ,USA"},
                new Reservation {ClientName = "FlipKart Portal", Location = "FlipKart, India"},
                new Reservation {ClientName = "Jabong Portal", Location = "Jabong, India"}
            };

            reservationSampleList.ToList().ForEach(res =>AddReservation(res));

        }

        public Dictionary<int, Reservation> ReservationDict { get; set; }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return ReservationDict.Values.ToList(); ;
        }

        public Reservation GetReservation(int reservationId) => ReservationDict[reservationId];
        
        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.RservationId == 0)
            {
                reservation.RservationId = ReservationDict.Count + 1;
                ReservationDict.Add(reservation.RservationId, reservation);
            }
            else
            {
                ReservationDict[reservation.RservationId] = reservation;
            }
            return reservation;
        }

        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);

        public bool DeleteReservation(int reservationId) => ReservationDict.Remove(reservationId);
        
    }
}
