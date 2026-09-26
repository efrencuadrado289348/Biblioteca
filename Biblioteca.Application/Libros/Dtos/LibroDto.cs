namespace Biblioteca.Application.Libros.Dtos;

public sealed record AutorDto(Guid Id, string Nombre, string? Nacionalidad);

public sealed record CategoriaDto(Guid Id, string Nombre, string? Descripcion);

public sealed record LibroDto(
    Guid Id,
    string Titulo,
    string Isbn,
    int AnioPublicacion,
    AutorDto Autor,
    CategoriaDto Categoria);