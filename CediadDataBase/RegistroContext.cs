using Microsoft.EntityFrameworkCore;

namespace CediadDataBase;

public class RegistroContext : DbContext
{
    public RegistroContext(DbContextOptions<RegistroContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de las relaciones utilizando Fluent API
        modelBuilder.Entity<Consumision>()
            .HasOne(c => c.Consumidor)
            .WithMany()
            .HasForeignKey(c => c.ConsumidorId)
            .OnDelete(DeleteBehavior.Restrict); // Evitar la acción en cascada

        modelBuilder.Entity<Suscripcion>()
            .HasOne(s => s.Cliente)
            .WithMany()
            .HasForeignKey(s => s.ClienteId)
            .OnDelete(DeleteBehavior.Restrict); // Evitar la acción en cascada
    }
    public DbSet<Registro> Registros => Set<Registro>();
    public DbSet<Persona> Personas => Set<Persona>();
    public DbSet<Consumision> Consumisiones => Set<Consumision>();
    public DbSet<Suscripcion> Suscripciones => Set<Suscripcion>();
}
