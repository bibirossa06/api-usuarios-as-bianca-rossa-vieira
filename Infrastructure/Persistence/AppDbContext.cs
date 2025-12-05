using APIUsuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIUsuarios.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var usuario = modelBuilder.Entity<Usuario>();
        usuario.ToTable("Usuarios");
        usuario.HasKey(u => u.Id);
        usuario.Property(u => u.Nome).IsRequired().HasMaxLength(200);
        usuario.Property(u => u.Email).IsRequired().HasMaxLength(255);
        usuario.HasIndex(u => u.Email).IsUnique();
        usuario.Property(u => u.Senha).IsRequired().HasMaxLength(200);
        usuario.Property(u => u.Ativo).HasDefaultValue(true);
        usuario.Property(u => u.DataCriacao);
        usuario.Property(u => u.DataAtualizacao);
    }
}
