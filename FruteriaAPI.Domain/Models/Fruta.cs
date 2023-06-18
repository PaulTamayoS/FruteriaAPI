using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruteriaAPI.Domain.Models
{
    public class Fruta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        [Required]        
        public decimal Precio { get; set; }
        public string Comentarios { get; set; }

    }
}
