using Microsoft.EntityFrameworkCore;

namespace Veiculos.Dominio.Repositorio
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }

        public Db() : base()
        {
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Exemple>().ToTable("exemples");
            */
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseLazyLoadingProxies();
               // optionsBuilder.UseMySql("Server=xx;User Id=xx;Password=xx;Database=xx;convert zero datetime=True");

            }
        }
    }
}
