using LinqToDB.Mapping;

namespace WebApplication1.Domain;

public record Person
(
    [property: PrimaryKey] Guid Id,
    string Name,
    DateTime Birthday
);
