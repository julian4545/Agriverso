
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;

namespace Agriverso.dbcontext
{
    public class AgriversoDbContext : DbContext
    {
        public AgriversoDbContext(DbContextOptions<AgriversoDbContext> options) : base(options)
        {
        }
        public DbSet<DetalleRecolector> DetalleRecolector { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Granjero> Granjero { get; set; }
        public DbSet<PartidaRecolector> PartidaRecolector { get; set; }
        public DbSet<PosicionRecolectorPartida> PosicionRecolectorPartida { get; set; }
        public DbSet<Recoleccion> Recoleccion { get; set; }

        public DbSet<Recolector> Recolector { get; set; }

        public DbSet<Residuo> Residuo { get; set; }

        public DbSet<TipoResiduo> TipoResiduo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // para crear relaciones posiblemente no se implementa 
            //modelBuilder.Entity<Crew>().HasKey(e => e.Id);
            //nodelBuilder.Entity<Crew>().Haskey(e = e.UserTypeld);

        }





    }
}