using Microsoft.EntityFrameworkCore;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Dominio.AcessoDados
{
    public class Db : DbContext
    {

        public DbSet<Marca> Marcas {get;set;}
        public DbSet<Modelo> Modelos {get;set;}
        public DbSet<Anuncio> Anuncios {get;set;}
        public DbSet<Usuario> Usuarios {get;set;}

        public Db(DbContextOptions<Db> options) : base(options)
        {
        }

        public Db() : base()
        {
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().ToTable("marcas");
            modelBuilder.Entity<Modelo>().ToTable("modelos");
            modelBuilder.Entity<Anuncio>().ToTable("anuncios");
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseMySql(ConfiguracaoDB.StringConexao);
            }
        }
    }
}
