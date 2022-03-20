using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using WebApplication1.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLinqToDbContext<AppDataConnection>((sp, options) =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Default"));
    options.UseDefaultLogging(sp);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var dataConnection = scope.ServiceProvider.GetService<AppDataConnection>();
    //dataConnection.CreateTable<Person>();
}

await app.RunAsync();
