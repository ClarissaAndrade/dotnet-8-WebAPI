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
        public async Task<ActionResult<IEnumerable<Deliverer>>> GetDeliverers()
        {
            return await _context.Deliverers.ToListAsync();
        }

        // GET: api/Deliverers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deliverer>> GetDeliverer(int id)
        {
            var deliverer = await _context.Deliverers.FindAsync(id);

            if (deliverer == null)
            {
                return NotFound();
            }

            return deliverer;
        }

        // PUT: api/Deliverers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliverer(int id, Deliverer deliverer)
        {
            if (id != deliverer.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliverer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<Deliverer>> PostDeliverer(Deliverer deliverer)
        {
            _context.Deliverers.Add(deliverer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliverer", new { id = deliverer.Id }, deliverer);
        }

        // DELETE: api/Deliverers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliverer(int id)
        {
            var deliverer = await _context.Deliverers.FindAsync(id);
            if (deliverer == null)
            {
                return NotFound();
            }

            _context.Deliverers.Remove(deliverer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DelivererExists(int id)
        {
            return _context.Deliverers.Any(e => e.Id == id);
        }
    }
}
