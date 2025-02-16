using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OohGasAPI.Context;
using OohGasAPI.DTOs;
using OohGasAPI.Migrations;
using OohGasAPI.Models;

namespace OohGasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BrandDTO>> GetBrands()
        {
            return _context.Brands?
                .Select(b => new BrandDTO
                    {
                        Id = b.Id,
                        NickName = b.NickName,
                        LegalName = b.LegalName,
                        Cnpj = b.Cnpj,
                        City = b.City,
                        Distance = b.Distance
                    })
                    .ToList() ?? [];
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public ActionResult<Brand> GetBrand(int id)
        {
            var brand = _context.Brands?.Find(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/Deliverers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBrand(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }

            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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
        public ActionResult<Brand> PostBrand(BrandDTO brandDto)
        {
            if (brandDto == null)
            {
                return BadRequest(new { Message = "Os dados da marca são inválidos." });
            }

            if (_context.Brands == null)
            {
                return StatusCode(500, new { Message = "Erro interno: O banco de dados não está disponível." });
            }

            var brand = new Brand
            {
                NickName = brandDto.NickName,
                LegalName = brandDto.LegalName,
                Cnpj = brandDto.Cnpj,
                City = brandDto.City,
                Distance = brandDto.Distance
            };

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            var brand = _context.Brands?.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands?.Remove(brand);
            _context.SaveChanges();

            return NoContent();
        }

        private bool BrandExists(int id)
        {
            return _context.Brands?.Any(e => e.Id == id) ?? false;
        }
    }
}
