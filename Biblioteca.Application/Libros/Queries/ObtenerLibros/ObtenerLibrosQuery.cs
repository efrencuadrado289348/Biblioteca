using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;

namespace Biblioteca.Application.Libros.Queries.ObtenerLibros;

public sealed record ObtenerLibrosQuery : IQuery<IReadOnlyList<LibroDto>>;