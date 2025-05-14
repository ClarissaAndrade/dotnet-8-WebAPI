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
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _context.Products?
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToList();

            return products ?? [];
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Products?.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        [HttpPost]
        public ActionResult<Product> PostProduct(ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest(new { Message = "Os dados do produto são inválidos." });
            }

            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                return BadRequest(new { Message = "O nome do produto é obrigatório." });
            }

            if (_context.Products == null)
            {
                return StatusCode(500, new { Message = "Erro interno: O banco de dados não está disponível." });
            }

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CaskPrice = productDto.CaskPrice,
                DeliveryFee = productDto.DeliveryFee,
                CategoryId = productDto.CategoryId,
                BrandId = productDto.BrandId
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products?.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products?.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products?.Any(e => e.Id == id) ?? false;
        }
    }
}
