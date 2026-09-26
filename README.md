# Biblioteca – Consulta de catálogo

API REST para consultar libros, autores y categorías de una biblioteca, desarrollada con **Clean Architecture**, **DDD** y **CQRS** sobre **.NET 10**, con persistencia en **SQL Server** mediante **Entity Framework Core**.

## Arquitectura

```
Core/
├── Biblioteca.Domain          Entidades (Libro, Autor, Categoria), Value Object Isbn, excepciones de dominio
└── Biblioteca.Application     Queries CQRS, handlers, DTOs e interfaz del repositorio
Infrastructure/
└── Biblioteca.Infrastructure  EF Core: DbContext, configuraciones, datos semilla, repositorio y migraciones
Presenters/
└── Biblioteca.Api             Web API con controladores (raíz de composición)
```

**Regla de dependencias:** `Api → Application → Domain` e `Infrastructure → Application → Domain`. El dominio no depende de ninguna otra capa ni de EF Core.

### Conceptos aplicados

- **DDD:** `Libro` es el aggregate root; `Isbn` es un value object que valida el formato al crearse; las entidades protegen su estado con setters privados.
- **CQRS:** cada caso de uso es una query con su handler (`IQuery` / `IQueryHandler`).
- **Inversión de dependencias:** Application define `ILibroRepository` e Infrastructure lo implementa.

## Casos de uso

| Query | Método | Endpoint |
|---|---|---|
| 1. Consultar todos los libros | GET | `/api/libros` |
| 2. Consultar un libro por ID | GET | `/api/libros/{id}` |
| 3. Consultar libros por categoría | GET | `/api/categorias/{categoriaId}/libros` |

## Cómo ejecutar

1. Requisitos: Visual Studio 2026 con .NET 10 y SQL Server LocalDB.
2. Abrir `Biblioteca.slnx` y establecer `Biblioteca.Api` como proyecto de inicio.
3. En la **Consola del Administrador de paquetes**, con proyecto predeterminado `Biblioteca.Infrastructure`, ejecutar:
```powershell
   Update-Database
```
   Esto crea la base de datos `BibliotecaDb` con datos de prueba.
4. Ejecutar con **F5** y probar los endpoints con el archivo `Biblioteca.Api.http`.

## Datos de prueba

| Tipo | Id | Nombre |
|---|---|---|
| Categoría | `c0000000-0000-0000-0000-000000000001` | Novela |
| Categoría | `c0000000-0000-0000-0000-000000000002` | Ingeniería de Software |
| Libro | `b0000000-0000-0000-0000-000000000001` | Cien años de soledad |
| Libro | `b0000000-0000-0000-0000-000000000003` | Clean Architecture |