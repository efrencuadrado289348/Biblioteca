using Biblioteca.Application.Abstractions;
using Biblioteca.Infrastructure.Persistence;
using Biblioteca.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BibliotecaDb")
            ?? throw new InvalidOperationException("Falta la cadena de conexión 'BibliotecaDb'.");

        services.AddDbContext<BibliotecaDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<ILibroRepository, LibroRepository>();
        return services;
    }
}