using OohGasAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OohGasAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal CaskPrice { get; set; }
        public decimal DeliveryFee { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
