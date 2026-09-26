using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;

namespace Biblioteca.Application.Libros.Queries.ObtenerLibrosPorCategoria;

public sealed class ObtenerLibrosPorCategoriaHandler(ILibroRepository repository)
    : IQueryHandler<ObtenerLibrosPorCategoriaQuery, IReadOnlyList<LibroDto>>
{
    public async Task<IReadOnlyList<LibroDto>> HandleAsync(ObtenerLibrosPorCategoriaQuery query, CancellationToken ct = default)
    {
        var libros = await repository.ObtenerPorCategoriaAsync(query.CategoriaId, ct);
        return libros.Select(l => l.ToDto()).ToList();
    }
}