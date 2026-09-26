using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;
using Biblioteca.Application.Libros.Queries.ObtenerLibroPorId;
using Biblioteca.Application.Libros.Queries.ObtenerLibros;
using Biblioteca.Application.Libros.Queries.ObtenerLibrosPorCategoria;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("api/libros")]
public sealed class LibrosController : ControllerBase
{
    // Query 1: GET /api/libros
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LibroDto>>> ObtenerTodos(
        [FromServices] IQueryHandler<ObtenerLibrosQuery, IReadOnlyList<LibroDto>> handler,
        CancellationToken ct)
        => Ok(await handler.HandleAsync(new ObtenerLibrosQuery(), ct));

    // Query 2: GET /api/libros/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LibroDto>> ObtenerPorId(
        Guid id,
        [FromServices] IQueryHandler<ObtenerLibroPorIdQuery, LibroDto?> handler,
        CancellationToken ct)
    {
        var libro = await handler.HandleAsync(new ObtenerLibroPorIdQuery(id), ct);
        return libro is null ? NotFound() : Ok(libro);
    }

    // Query 3: GET /api/categorias/{categoriaId}/libros
    [HttpGet("~/api/categorias/{categoriaId:guid}/libros")]
    public async Task<ActionResult<IReadOnlyList<LibroDto>>> ObtenerPorCategoria(
        Guid categoriaId,
        [FromServices] IQueryHandler<ObtenerLibrosPorCategoriaQuery, IReadOnlyList<LibroDto>> handler,
        CancellationToken ct)
        => Ok(await handler.HandleAsync(new ObtenerLibrosPorCategoriaQuery(categoriaId), ct));
}