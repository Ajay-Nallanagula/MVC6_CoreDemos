using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ApiDemosChp20.Models
{
    public class Reservation
    {
        public int RservationId { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
    }
}
