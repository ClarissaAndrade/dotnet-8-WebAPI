using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace OohGasAPI.Models;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }

    [Key]
    public int CategoryId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
