using Biblioteca.Application.Abstractions;
using Biblioteca.Domain.Entities.Libros;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories;

internal sealed class LibroRepository(BibliotecaDbContext context) : ILibroRepository
{
    // AsNoTracking: solo lectura, evita el costo del seguimiento de cambios.
    // Include: carga el autor y la categoría en la misma consulta (JOIN).
    private IQueryable<Libro> LibrosConRelaciones => context.Libros
        .AsNoTracking()
        .Include(l => l.Autor)
        .Include(l => l.Categoria);

    public async Task<IReadOnlyList<Libro>> ObtenerTodosAsync(CancellationToken ct = default)
        => await LibrosConRelaciones.OrderBy(l => l.Titulo).ToListAsync(ct);

    public Task<Libro?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        => LibrosConRelaciones.FirstOrDefaultAsync(l => l.Id == id, ct);

    public async Task<IReadOnlyList<Libro>> ObtenerPorCategoriaAsync(Guid categoriaId, CancellationToken ct = default)
        => await LibrosConRelaciones
            .Where(l => l.CategoriaId == categoriaId)
            .OrderBy(l => l.Titulo)
            .ToListAsync(ct);
}