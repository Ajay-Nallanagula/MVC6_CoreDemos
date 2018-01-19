using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using JWTAuthenticationSample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationSample.Controllers
{
    //[Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {
        [Authorize, HttpGet]
        public IEnumerable<Book> Get()
        {
           var currentUser = HttpContext.User;
            int userAge = 0;
            var booksList = new List<Book>
            {
                new Book {Author = "Ray Bradbury", Title = "Fahrenheit 451",AgeRestriction = true},
                new Book {Author = "Gabriel García Márquez", Title = "One Hundred years of Solitude",AgeRestriction = true},
                new Book {Author = "George Orwell", Title = "1984"},
                new Book {Author = "Anais Nin", Title = "Delta of Venus"}
            };

            if (currentUser.HasClaim(p=>p.Type.Equals(ClaimTypes.DateOfBirth)))
            {
                DateTime birthDate = DateTime.Parse(currentUser.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.DateOfBirth))?.Value);
                userAge = DateTime.Today.Year - birthDate.Year;
            }

            if (userAge > 18)
            {
                return booksList.Where(b => !b.AgeRestriction).ToList();
            }

            return booksList;
        }

        [Route("ShowBooks")]
        [Authorize,HttpPost]
        public IActionResult ShowBooks([FromBody]IList<Book> books)
        {
            return View(books.ToList());
        }
    }
}