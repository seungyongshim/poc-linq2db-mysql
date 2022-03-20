using LinqToDB.Mapping;

namespace WebApplication1.Domain;

public record Person
(
    [property: PrimaryKey] Guid Id,
    string Name,
    DateTime Birthday,
    [property: Column(DataType = LinqToDB.DataType.Json)]
    PersonDetail Detail
);

public record PersonDetail
(
    string Tag1,
    string Tag2
);
