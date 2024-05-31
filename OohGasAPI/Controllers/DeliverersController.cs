using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OohGasAPI.Context;
using OohGasAPI.Models;

namespace OohGasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliverersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeliverersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Deliverer>> GetDeliverers()
        {
            return _context.Deliverers.ToList();
        }

        // GET: api/Deliverers/5
        [HttpGet("{id}")]
        public ActionResult<Deliverer> GetDeliverer(int id)
        {
            var deliverer = _context.Deliverers.Find(id);

            {
                return NotFound();
            }

            return deliverer;
        }

        // PUT: api/Deliverers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDeliverer(int id, Deliverer deliverer)
        {
            if (id != deliverer.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliverer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DelivererExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Deliverers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Deliverer> PostDeliverer(Deliverer deliverer)
        {
            _context.Deliverers.Add(deliverer);
            _context.SaveChanges();

            return CreatedAtAction("GetDeliverer", new { id = deliverer.Id }, deliverer);
        }

        // DELETE: api/Deliverers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDeliverer(int id)
        {
            var deliverer = _context.Deliverers.Find(id);
            if (deliverer == null)
            {
                return NotFound();
            }

            _context.Deliverers.Remove(deliverer);
            _context.SaveChanges();

            return NoContent();
        }

        private bool DelivererExists(int id)
        {
            return _context.Deliverers.Any(e => e.Id == id);
        }
    }
}
