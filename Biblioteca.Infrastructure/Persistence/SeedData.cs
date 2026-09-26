namespace Biblioteca.Infrastructure.Persistence;

internal static class SeedData
{
    // Autores
    public static readonly Guid GarciaMarquezId = Guid.Parse("a0000000-0000-0000-0000-000000000001");
    public static readonly Guid RobertMartinId = Guid.Parse("a0000000-0000-0000-0000-000000000002");
    public static readonly Guid EricEvansId = Guid.Parse("a0000000-0000-0000-0000-000000000003");

    // Categorías
    public static readonly Guid NovelaId = Guid.Parse("c0000000-0000-0000-0000-000000000001");
    public static readonly Guid IngSoftwareId = Guid.Parse("c0000000-0000-0000-0000-000000000002");

    // Libros
    public static readonly Guid CienAniosId = Guid.Parse("b0000000-0000-0000-0000-000000000001");
    public static readonly Guid AmorColeraId = Guid.Parse("b0000000-0000-0000-0000-000000000002");
    public static readonly Guid CleanArchId = Guid.Parse("b0000000-0000-0000-0000-000000000003");
    public static readonly Guid DddId = Guid.Parse("b0000000-0000-0000-0000-000000000004");
}