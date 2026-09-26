using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.Entities.Categorias;

public sealed class Categoria : Entity
{
    public string Nombre { get; private set; } = null!;
    public string? Descripcion { get; private set; }

    private Categoria() { } // Requerido por EF Core
}