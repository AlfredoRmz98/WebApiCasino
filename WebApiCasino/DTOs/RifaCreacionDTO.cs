using System.ComponentModel.DataAnnotations;

namespace WebApiCasino.DTOs
{
    public class RifaCreacionDTO
    {
        [Required]
        [StringLength(maximumLength:100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<int> ParticipantesIds { get; set; }
    }
}
