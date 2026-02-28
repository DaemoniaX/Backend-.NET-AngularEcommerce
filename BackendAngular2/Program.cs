using Microsoft.Data.SqlClient;
using BackendAngular2.Models;

var builder = WebApplication.CreateBuilder(args);

//adding multi-connection-string Failover with for the moment AWS, the idea is simple : we put 2 connection string, and we test each of them and we put the one active in the variable

string[] connectionNames = { "AwsDB", "LocalDB", "AzureDB" };
string activeConnectionString = "";


foreach (var name in connectionNames)
{
    string connecStr = builder.Configuration.GetConnectionString(name) ?? "";
    if (string.IsNullOrEmpty(connecStr)) continue;

    try
    {
        using (var connection = new SqlConnection(connecStr))
        {
            connection.Open();
        }
        activeConnectionString = connecStr;
        break;
    }
    catch
    {

    }
}

// I said that the idea was simple, but it took some time to make this 2 lines down here
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
