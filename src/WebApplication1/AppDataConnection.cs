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

    }
}
