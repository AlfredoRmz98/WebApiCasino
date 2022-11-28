using System.ComponentModel.DataAnnotations;

namespace WebApiCasino.DTOs
{
    public class RifaPatchDTO
    {
        [Required]
       [StringLength(maximumLength:100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
       public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
