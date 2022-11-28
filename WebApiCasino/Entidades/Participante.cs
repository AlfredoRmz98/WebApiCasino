using System.ComponentModel.DataAnnotations;

namespace WebApiCasino.Entidades
{
    public class Participante
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string Nombre { get; set; }


        public List<ParticipanteRifa> ParticipanteRifa { get; set; }
  
    }
}
