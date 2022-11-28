using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.Entidades;

namespace WebApiCasino
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParticipanteRifa>()
                .HasKey(al => new { al.ParticipanteId, al.RifaId });
        }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Rifa> Rifas { get; set; }
        public DbSet<ParticipanteRifa> ParticipanteRifas { get; set; }
        public DbSet<Carta> Cartas { get; set; }
    }
}
