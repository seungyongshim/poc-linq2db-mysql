using System.Text.Json;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using WebApplication1.Domain;

public class AppDataConnection : DataConnection
{
    public ITable<Person> People => GetTable<Person>();

    public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
        : base(options)
    {
        MappingSchema.SetConverter<PersonDetail, DataParameter>(
          list => new DataParameter("", JsonSerializer.Serialize(list)));

        MappingSchema.SetConverter<string, PersonDetail>(
          str => JsonSerializer.Deserialize<PersonDetail>(str));

    }
}
