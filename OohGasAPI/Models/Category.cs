using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OohGasAPI.Models;

public class Category
{
    public Category()
    {
        Subcategories = new Collection<Category>();
        Products = new Collection<Product>();
    }

    [Key]
    public int Id { get; set; }

    public int? IdFather { get; set; }

    [ForeignKey("IdFather")]
    public Category? ParentCategory { get; set; }

    [Required]
    [StringLength(80)]
    public required string Name { get; set; }

    public ICollection<Category> Subcategories { get; set; }
    public ICollection<Product>? Products { get; set; }
}
