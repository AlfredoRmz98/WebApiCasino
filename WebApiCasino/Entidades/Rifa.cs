namespace WebApiCasino.Entidades
{
    public class Rifa
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public List<Participante> Participante { get; set; }
        public List<Carta> Carta { get; set; }
        public List<ParticipanteRifa> ParticipanteRifa { get; set; }
        public List<Premio> Premio { get; set; }
    }
}
