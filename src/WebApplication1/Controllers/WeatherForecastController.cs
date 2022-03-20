using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    AppDataConnection Connection;

    public PeopleController(AppDataConnection connection)
    {
        Connection = connection;
    }

    [HttpGet]
    public Task<Person[]> ListPeople() =>
        Connection.People.ToArrayAsync();

    [HttpGet("{id}")]
    public Task<Person?> GetPerson(Guid id) =>
        Connection.People.SingleOrDefaultAsync(person => person.Id == id);

    [HttpDelete("{id}")]
    public Task<int> DeletePerson(Guid id) =>
        Connection.People.Where(person => person.Id == id).DeleteAsync();

    [HttpPatch]
    public Task<int> UpdatePerson(Person person) =>
        Connection.UpdateAsync(person);

    [HttpPatch("{id}/new-name")]
    public Task<int> UpdatePersonName(Guid id, string newName) =>
        Connection.People.Where(person => person.Id == id)
                         .Set(person => person.Name, newName)
                         .UpdateAsync();

    [HttpPut]
    public Task<int> InsertPerson(Person person) =>
        Connection.InsertOrReplaceAsync(person);
}
