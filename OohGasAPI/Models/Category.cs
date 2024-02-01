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
    public int Id { get; set; }
    
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required]
    public Boolean FlgGeneral { get; set; }

    public ICollection<Product>? Products { get; set; }
}
