using Biblioteca.Domain.Entities.Autores;
using Biblioteca.Domain.Entities.Categorias;
using Biblioteca.Domain.Entities.Libros;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence;

public sealed class BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : DbContext(options)
{
    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    // Aplica automáticamente todas las clases IEntityTypeConfiguration de este proyecto
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaDbContext).Assembly);
}