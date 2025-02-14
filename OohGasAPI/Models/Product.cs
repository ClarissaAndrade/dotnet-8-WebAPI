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

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Cost { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal CaskPrice { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal CaskCost { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal DeliveryFee { get; set; }

    [Required]
    public int CategoryId { get; set; }

    // Propriedade de navegação
    [ForeignKey("CategoryId")]
    public Category Category { get; set; } = null!;

}
