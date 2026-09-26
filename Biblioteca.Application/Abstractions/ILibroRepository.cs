using Biblioteca.Domain.Entities.Libros;

namespace Biblioteca.Application.Abstractions;

public interface ILibroRepository
{
    Task<IReadOnlyList<Libro>> ObtenerTodosAsync(CancellationToken ct = default);
    Task<Libro?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Libro>> ObtenerPorCategoriaAsync(Guid categoriaId, CancellationToken ct = default);
}