using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OohGasAPI.Models
{
    public class Brand
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public required string NickName { get; set; }

        [Required]
        [StringLength(80)]
        public required string LegalName { get; set; }

        [Required]
        [StringLength(20)]
        public required string Cnpj { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        [Required]
        [StringLength(25)]
        public required string City { get; set; }

        [Required]
        public int Distance { get; set; }

    }
}
