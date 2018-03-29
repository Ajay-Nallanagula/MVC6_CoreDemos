using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemosChp20.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemosChp20.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IRepository _repository;

        public ReservationController(IRepository repo)
        {
            _repository = repo;
        }

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Reservation> patch)
        {
            var reservation = Get(id);
            if (reservation == null)
            {
                return NotFound();
            }
            patch.ApplyTo(reservation);
            return Ok();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return _repository.GetAllReservations();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            return _repository.GetReservation(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Reservation reservation)
        {
            _repository.AddReservation(reservation);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Reservation reservation)
        {
            _repository.UpdateReservation(reservation);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteReservation(id);
        }

        
    }
}
