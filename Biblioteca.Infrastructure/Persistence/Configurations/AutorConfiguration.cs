using Biblioteca.Domain.Entities.Autores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Persistence.Configurations;

internal sealed class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("Autores");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Nombre).HasMaxLength(150).IsRequired();
        builder.Property(a => a.Nacionalidad).HasMaxLength(80);

        builder.HasData(
            new { Id = SeedData.GarciaMarquezId, Nombre = "Gabriel García Márquez", Nacionalidad = "Colombiana" },
            new { Id = SeedData.RobertMartinId, Nombre = "Robert C. Martin", Nacionalidad = "Estadounidense" },
            new { Id = SeedData.EricEvansId, Nombre = "Eric Evans", Nacionalidad = "Estadounidense" });
    }
}