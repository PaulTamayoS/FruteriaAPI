using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruteriaAPI.Domain.Models
{
    public class FrutaFormattedPriceResponse
    {       
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        [Required]        
        public string Precio { get; set; }       

    }
}
