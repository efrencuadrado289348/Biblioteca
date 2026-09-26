using Biblioteca.Domain.Entities.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Persistence.Configurations;

internal sealed class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nombre).HasMaxLength(100).IsRequired();
        builder.HasIndex(c => c.Nombre).IsUnique();
        builder.Property(c => c.Descripcion).HasMaxLength(300);

        builder.HasData(
            new { Id = SeedData.NovelaId, Nombre = "Novela", Descripcion = "Obras de ficción narrativa" },
            new { Id = SeedData.IngSoftwareId, Nombre = "Ingeniería de Software", Descripcion = "Diseño y construcción de software" });
    }
}