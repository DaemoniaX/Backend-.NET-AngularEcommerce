using Microsoft.Data.SqlClient;
using BackendAngular2.Models;

var builder = WebApplication.CreateBuilder(args);

//adding multi-connection-string Failover with for the moment AWS, l'idéologie est simple : on met 2 connection string, et on les test un par un et on met celui qui est online en définitif,

string[] connectionNames = { "AwsDB", "LocalDB" };
string activeConnectionString = "";


foreach (var name in connectionNames)
{
    string connecStr = builder.Configuration.GetConnectionString(name) ?? "";
    if (string.IsNullOrEmpty(connecStr)) continue;

    try
    {
        Console.WriteLine($"Test de la base [{name}]...");
        using (var connection = new SqlConnection(connecStr))
        {
            connection.Open();
        }
        Console.WriteLine($"✅ SUCCÈS : La base [{name}] est en ligne !");
        activeConnectionString = connecStr;
        break;
    }
    catch
    {
        Console.WriteLine($"❌ ÉCHEC : La base [{name}] est injoignable.");
    }
}

if (string.IsNullOrEmpty(activeConnectionString))
{
    throw new Exception("CRITIQUE : Absolument aucune base de données n'est en ligne !");
}

// je dit que l'idée était simple, mais j'ai mis du temps avant de comprendre comment faire ces 2 lignes
var dbConfig = new DatabaseConfig { ConnectionString = activeConnectionString };
builder.Services.AddSingleton(dbConfig);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Frontend Adress
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAngular");

app.UseAuthorization();
app.MapControllers();
app.Run();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
