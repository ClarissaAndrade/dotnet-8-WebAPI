using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OohGasAPI.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? CaskPrice { get; set; } = 0;

    [Column(TypeName = "decimal(10,2)")]
    public decimal? DeliveryFee { get; set; } = 0;

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; } = null!;

    public int? BrandId { get; set; } = null;

    [ForeignKey("BrandId")]
    public Brand? Brand { get; set; } = null!;

    [Required]
    public byte Status { get; set; }
}
