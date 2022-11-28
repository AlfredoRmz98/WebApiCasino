namespace WebApiCasino.Entidades
{
    public class Premio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Rifa> Rifa { get; set; }
        
    }
}
