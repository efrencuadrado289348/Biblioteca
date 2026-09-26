using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;

namespace Biblioteca.Application.Libros.Queries.ObtenerLibrosPorCategoria;

public sealed record ObtenerLibrosPorCategoriaQuery(Guid CategoriaId) : IQuery<IReadOnlyList<LibroDto>>;