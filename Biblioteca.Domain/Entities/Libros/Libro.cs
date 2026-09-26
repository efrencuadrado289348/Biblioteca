using Biblioteca.Domain.Common;
using Biblioteca.Domain.Entities.Autores;
using Biblioteca.Domain.Entities.Categorias;
using Biblioteca.Domain.Entities.Libros.ValueObjects;

namespace Biblioteca.Domain.Entities.Libros;

public sealed class Libro : Entity
{
    public string Titulo { get; private set; } = null!;
    public Isbn Isbn { get; private set; } = null!;
    public int AnioPublicacion { get; private set; }

    public Guid AutorId { get; private set; }
    public Autor Autor { get; private set; } = null!;

    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; private set; } = null!;

    private Libro() { } // Requerido por EF Core
}