using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PacientesContext>(p => p.UseInMemoryDatabase("PacientesDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async([FromServices] PacientesContext DbContext) =>
{
    DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en Memoria "+ DbContext.Database.IsInMemory());
});

app.Run();
