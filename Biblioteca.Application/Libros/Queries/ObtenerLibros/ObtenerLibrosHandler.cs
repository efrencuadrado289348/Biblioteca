using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;

namespace Biblioteca.Application.Libros.Queries.ObtenerLibros;

public sealed class ObtenerLibrosHandler(ILibroRepository repository)
    : IQueryHandler<ObtenerLibrosQuery, IReadOnlyList<LibroDto>>
{
    public async Task<IReadOnlyList<LibroDto>> HandleAsync(ObtenerLibrosQuery query, CancellationToken ct = default)
    {
        var libros = await repository.ObtenerTodosAsync(ct);
        return libros.Select(l => l.ToDto()).ToList();
    }
}