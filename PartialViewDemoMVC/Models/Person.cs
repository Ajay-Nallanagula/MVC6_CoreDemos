using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewDemoMVC.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string LandPhone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Profession { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string Nationality { get; set; }
    }

    public class Persons
    {
        public IEnumerable<Person> AllPersonsList;

        public Persons()
        {
            AllPersonsList = new List<Person>();
        }
    }
}
