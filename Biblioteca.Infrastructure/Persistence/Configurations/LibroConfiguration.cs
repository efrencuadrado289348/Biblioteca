using Biblioteca.Domain.Entities.Libros;
using Biblioteca.Domain.Entities.Libros.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Persistence.Configurations;

internal sealed class LibroConfiguration : IEntityTypeConfiguration<Libro>
{
    public void Configure(EntityTypeBuilder<Libro> builder)
    {
        builder.ToTable("Libros");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Titulo).HasMaxLength(200).IsRequired();
        builder.Property(l => l.AnioPublicacion).IsRequired();

        // Value Object Isbn -> columna nvarchar(13)
        builder.Property(l => l.Isbn)
            .HasConversion(isbn => isbn.Value, value => Isbn.Create(value))
            .HasMaxLength(13)
            .IsRequired();
        builder.HasIndex(l => l.Isbn).IsUnique();

        // Relaciones: un libro tiene un autor y una categoría
        builder.HasOne(l => l.Autor).WithMany().HasForeignKey(l => l.AutorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(l => l.Categoria).WithMany().HasForeignKey(l => l.CategoriaId).OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new { Id = SeedData.CienAniosId, Titulo = "Cien años de soledad", Isbn = Isbn.Create("9780307474728"), AnioPublicacion = 1967, AutorId = SeedData.GarciaMarquezId, CategoriaId = SeedData.NovelaId },
            new { Id = SeedData.AmorColeraId, Titulo = "El amor en los tiempos del cólera", Isbn = Isbn.Create("9780307387264"), AnioPublicacion = 1985, AutorId = SeedData.GarciaMarquezId, CategoriaId = SeedData.NovelaId },
            new { Id = SeedData.CleanArchId, Titulo = "Clean Architecture", Isbn = Isbn.Create("9780134494166"), AnioPublicacion = 2017, AutorId = SeedData.RobertMartinId, CategoriaId = SeedData.IngSoftwareId },
            new { Id = SeedData.DddId, Titulo = "Domain-Driven Design", Isbn = Isbn.Create("9780321125217"), AnioPublicacion = 2003, AutorId = SeedData.EricEvansId, CategoriaId = SeedData.IngSoftwareId });
    }
}