using CatalogoMotos2026.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CatalogoMotos2026.Dados;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes)
    {
    }

    public DbSet<Motocicleta> Motocicletas => Set<Motocicleta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Motocicleta>(entidade =>
        {
            entidade.HasKey(m => m.Id);
            entidade.Property(m => m.Modelo).IsRequired().HasMaxLength(100);
            entidade.Property(m => m.Familia).IsRequired().HasMaxLength(100);
            entidade.Property(m => m.Cilindrada).IsRequired();
            entidade.Property(m => m.Ano).IsRequired().HasDefaultValue(2026);
        });
    }
}
