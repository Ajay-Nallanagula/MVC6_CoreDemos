using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemosChp20.Models
{
    public class AllReservations
    {
        public AllReservations()
        {
            AllReservationsList = new List<Reservation>();
        }
        public List<Reservation> AllReservationsList { get; set; }
    }
}
