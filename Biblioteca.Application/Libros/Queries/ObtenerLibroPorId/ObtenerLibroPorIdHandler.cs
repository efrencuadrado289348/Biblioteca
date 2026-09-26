using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;

namespace Biblioteca.Application.Libros.Queries.ObtenerLibroPorId;

public sealed class ObtenerLibroPorIdHandler(ILibroRepository repository)
    : IQueryHandler<ObtenerLibroPorIdQuery, LibroDto?>
{
    public async Task<LibroDto?> HandleAsync(ObtenerLibroPorIdQuery query, CancellationToken ct = default)
    {
        var libro = await repository.ObtenerPorIdAsync(query.Id, ct);
        return libro?.ToDto();
    }
}