using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OohGasAPI.Models
{
    public class Deliverer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? NickName { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DtBirthday { get; set; }

        [Required]
        [StringLength(20)]
        public string? Cpf { get; set; }

        [StringLength(20)]
        public string? Rg { get; set; }

        [Required]
        [StringLength(20)]
        public string? Cnh { get; set; }

        [Required]
        [StringLength(5)]
        public string? CnhCategory { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DtCnhExpiry { get; set; }


        [Required]
        [StringLength(30)]
        public string? Phone { get; set; }


        [Required]
        public byte Status { get; set; }
    }
}
