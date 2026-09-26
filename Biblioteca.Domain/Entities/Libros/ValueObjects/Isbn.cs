using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Entities.Libros.ValueObjects;

public sealed record Isbn
{
    public string Value { get; }

    private Isbn(string value) => Value = value;

    public static Isbn Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("El ISBN es obligatorio.");

        var normalized = value.Replace("-", string.Empty).Trim().ToUpperInvariant();

        var esIsbn13 = normalized.Length == 13 && normalized.All(char.IsDigit);
        var esIsbn10 = normalized.Length == 10
                       && normalized[..9].All(char.IsDigit)
                       && (char.IsDigit(normalized[9]) || normalized[9] == 'X');

        if (!esIsbn10 && !esIsbn13)
            throw new DomainException($"ISBN inválido: '{value}'.");

        return new Isbn(normalized);
    }

    public override string ToString() => Value;
}