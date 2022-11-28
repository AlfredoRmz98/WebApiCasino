namespace WebApiCasino.Entidades
{
    public class Carta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Gallo = 1;
        public int Diablo = 2;
        public int Dama = 3;
        public int Catrin = 4;
        public int Paraguas = 5;
        public int Sirena = 6;
        public int Escalera = 7;
        public int Botella = 8;
        public int Barril = 9;  
        public int Arbol = 10;
        public int Melon = 11;
        public int Valiente = 12;
        public int Gorrito  = 13;
        public int Muerte = 14;
        public int Pera = 15;
        public int Bandera = 16;
        public int Bandolon = 17;
        public int Violoncello = 18;    
        public int Garza = 19;
        public int Pajaro = 20;
        public int Mano = 21;
        public int Bota = 22;
        public int Luna = 23;
        public int Cotorro = 24;
        public int Borracho = 25;   
        public int Negrito = 26;
        public int Corazon = 27;
        public int Sandia = 28;
        public int Tambor = 29;
        public int Camaron = 30;
        public int Jaras = 31;
        public int Musico = 32;
        public int Arana = 33;
        public int Soldado = 34;
        public int Estrella = 35;
        public int Cazo = 36;
        public int Mundo = 37;
        public int Apache = 38;
        public int Nopal = 39;
        public int Alacran = 40;
        public int Rosa = 41;
        public int Calavera = 42;
        public int Campana = 43;
        public int Cantarito = 44;
        public int Venado = 45;
        public int Sol = 46;
        public int Corona = 47;
        public int Chalupa = 48;
        public int Pino = 49;
        public int Pescado = 50;
        public int Palma = 51;
        public int Maceta = 52;
        public int Arpa = 53;
        public int Rana = 54;

        public List<Participante> Participante { get; set; }
        public List<ParticipanteRifa> ParticipanteRifa { get; set; }
        public List<Rifa> Rifa { get; set; }
        public List<Premio> Premio { get; set; }
    }
    

}
