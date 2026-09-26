using Biblioteca.Domain.Common;

namespace Biblioteca.Domain.Entities.Autores;

public sealed class Autor : Entity
{
    public string Nombre { get; private set; } = null!;
    public string? Nacionalidad { get; private set; }

    private Autor() { } // Requerido por EF Core
}