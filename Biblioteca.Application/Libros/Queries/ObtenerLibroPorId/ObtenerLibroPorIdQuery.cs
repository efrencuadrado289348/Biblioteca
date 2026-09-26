using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;

namespace Biblioteca.Application.Libros.Queries.ObtenerLibroPorId;

public sealed record ObtenerLibroPorIdQuery(Guid Id) : IQuery<LibroDto?>;