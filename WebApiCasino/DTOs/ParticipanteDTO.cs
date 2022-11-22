using System.ComponentModel.DataAnnotations;

namespace WebApiCasino.DTOs
{
    public class ParticipanteDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        public string Nombre { get; set; }
    }
}
