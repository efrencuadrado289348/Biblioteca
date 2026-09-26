using Biblioteca.Domain.Entities.Libros;

namespace Biblioteca.Application.Libros.Dtos;

internal static class LibroMappings
{
    public static LibroDto ToDto(this Libro libro) => new(
        libro.Id,
        libro.Titulo,
        libro.Isbn.Value,
        libro.AnioPublicacion,
        new AutorDto(libro.Autor.Id, libro.Autor.Nombre, libro.Autor.Nacionalidad),
        new CategoriaDto(libro.Categoria.Id, libro.Categoria.Nombre, libro.Categoria.Descripcion));
}