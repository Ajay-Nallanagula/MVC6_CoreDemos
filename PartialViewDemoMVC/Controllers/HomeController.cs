using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartialViewDemoMVC.Models;

namespace PartialViewDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private Persons _persons;
        public HomeController()
        {
            _persons = GetAllPersons();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayPerson()
        {
            return View(_persons.AllPersonsList.ToList());
        }

        public IActionResult DisplayIndividualPerson(int id)
        {
            var person = _persons.AllPersonsList.FirstOrDefault(k => k.PersonId == id);
            return PartialView(person);
        }

        private static Persons GetAllPersons()
        {
            var persons = new Persons();
            persons.AllPersonsList = new List<Person>
            {
                new Person
                {
                    PersonId =1,
                    Address = "SomeJunkValue",
                    Age = "SomeJunkValue",
                    Dob = "SomeJunkValue",
                    Experience = "SomeJunkValue",
                    FirstName = "SomeJunkValue",
                    LastName = "SomeJunkValue",
                    Gender = "SomeJunkValue",
                    LandPhone = "SomeJunkValue",
                    Mobile = "SomeJunkValue",
                    Nationality = "SomeJunkValue"
                },
                new Person
                {
                    PersonId =2,
                    Address = "1SomeJunkValue",
                    Age = "1SomeJunkValue",
                    Dob = "1SomeJunkValue",
                    Experience = "1SomeJunkValue",
                    FirstName = "1SomeJunkValue",
                    LastName = "1SomeJunkValue",
                    Gender = "1SomeJunkValue",
                    LandPhone = "1SomeJunkValue",
                    Mobile = "1SomeJunkValue",
                    Nationality = "1SomeJunkValue"
                },
                new Person
                {
                    PersonId =3,
                    Address = "2SomeJunkValue",
                    Age = "2SomeJunkValue",
                    Dob = "2SomeJunkValue",
                    Experience = "2SomeJunkValue",
                    FirstName = "2SomeJunkValue",
                    LastName = "2SomeJunkValue",
                    Gender = "2SomeJunkValue",
                    LandPhone = "2SomeJunkValue",
                    Mobile = "2SomeJunkValue",
                    Nationality = "2SomeJunkValue"
                },
                new Person
                {
                    PersonId =4,
                    Address = "3SomeJunkValue",
                    Age = "3SomeJunkValue",
                    Dob = "3SomeJunkValue",
                    Experience = "3SomeJunkValue",
                    FirstName = "3SomeJunkValue",
                    LastName = "3SomeJunkValue",
                    Gender = "3SomeJunkValue",
                    LandPhone = "3SomeJunkValue",
                    Mobile = "3SomeJunkValue",
                    Nationality = "3SomeJunkValue"
                },
                new Person
                {
                    PersonId =5,
                    Address = "4SomeJunkValue",
                    Age = "4SomeJunkValue",
                    Dob = "4SomeJunkValue",
                    Experience = "4SomeJunkValue",
                    FirstName = "4SomeJunkValue",
                    LastName = "4SomeJunkValue",
                    Gender = "4SomeJunkValue",
                    LandPhone = "4SomeJunkValue",
                    Mobile = "4SomeJunkValue",
                    Nationality = "4SomeJunkValue"
                },
                new Person
                {
                    PersonId =6,
                    Address = "5SomeJunkValue",
                    Age = "5SomeJunkValue",
                    Dob = "5SomeJunkValue",
                    Experience = "5SomeJunkValue",
                    FirstName = "5SomeJunkValue",
                    LastName = "5SomeJunkValue",
                    Gender = "5SomeJunkValue",
                    LandPhone = "5SomeJunkValue",
                    Mobile = "5SomeJunkValue",
                    Nationality = "5SomeJunkValue"
                },

            }.ToList();

            return persons;
        }
    }
}