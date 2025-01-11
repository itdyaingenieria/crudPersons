using Microsoft.EntityFrameworkCore;
using Prueba_YamaAndrade.Models;


namespace Prueba_YamaAndrade.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            
        }

        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(tb =>
            {
                tb.HasKey(col => col.IdPersona);
                tb.Property(col => col.IdPersona)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombres).HasMaxLength(50);
                tb.Property(col => col.Apellidos).HasMaxLength(50);
                tb.Property(col => col.Identificacion).HasMaxLength(10);
                tb.Property(col => col.Genero).HasMaxLength(2);
                tb.Property(col => col.Fecha_nacimiento);
                tb.Property(col => col.Contrasena).HasMaxLength(10);
                tb.Property(col => col.Activo);
            });

            modelBuilder.Entity<Persona>().ToTable("Personas"); //Aqui se puede ajustar el nombre de la table en DB singular o pllural
        }

    }
}
