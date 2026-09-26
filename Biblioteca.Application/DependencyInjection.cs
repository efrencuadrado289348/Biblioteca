using Biblioteca.Application.Abstractions;
using Biblioteca.Application.Libros.Dtos;
using Biblioteca.Application.Libros.Queries.ObtenerLibroPorId;
using Biblioteca.Application.Libros.Queries.ObtenerLibros;
using Biblioteca.Application.Libros.Queries.ObtenerLibrosPorCategoria;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<ObtenerLibrosQuery, IReadOnlyList<LibroDto>>, ObtenerLibrosHandler>();
        services.AddScoped<IQueryHandler<ObtenerLibroPorIdQuery, LibroDto?>, ObtenerLibroPorIdHandler>();
        services.AddScoped<IQueryHandler<ObtenerLibrosPorCategoriaQuery, IReadOnlyList<LibroDto>>, ObtenerLibrosPorCategoriaHandler>();
        return services;
    }
}