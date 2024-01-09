using System.Formats.Tar;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<PacientesContext>(p => p.UseInMemoryDatabase("PacientesDB"));
builder.Services.AddSqlServer<PacientesContext>(builder.Configuration.GetConnectionString("cnPacientes"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async([FromServices] PacientesContext DbContext) =>
{
    DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en Memoria "+ DbContext.Database.IsInMemory());
});

app.MapGet("/api/pacientes", async([FromServices] PacientesContext DbContext) =>
{
    return Results.Ok(DbContext.Pacientes.Include(p => p.Empleado));
});

app.MapGet("/api/pacientes/prioridadAlta", async([FromServices] PacientesContext DbContext) =>
{
    return Results.Ok(DbContext.Pacientes.Where(p=> p.PrioridadPaciente == projectef.Models.Prioridad.Alta));
});

app.MapGet("/api/pacientes/MedicoaCargo", async([FromServices] PacientesContext DbContext) =>
{
    return Results.Ok(DbContext.Pacientes.Include(p => p.Empleado).Where(p=> p.PrioridadPaciente == projectef.Models.Prioridad.Alta));
});

app.MapPost("/api/pacientes/GuardarDatos", async([FromServices] PacientesContext DbContext, [FromBody] Paciente paciente) =>
{
    paciente.PacienteId = Guid.NewGuid();
    paciente.FechadeIngreso = DateTime.Now;
    
    await DbContext.Pacientes.AddAsync(paciente);

    await DbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/pacientes/ActualizarDatos/{id}", async([FromServices] PacientesContext DbContext, [FromBody] Paciente paciente, [FromRoute] Guid id) =>
{
    var PacienteActual = DbContext.Pacientes.Find(id);

    if (PacienteActual!= null)
    {
        PacienteActual.EmpleadoId = paciente.EmpleadoId;
        PacienteActual.Nombre = paciente.Nombre;
        PacienteActual.PrioridadPaciente = paciente.PrioridadPaciente;
        PacienteActual.Edad = paciente.Edad;

        await DbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/pacientes/borrar/{id}", async ([FromServices] PacientesContext DbContext, [FromRoute] Guid id) =>
{
    var PacienteActual = DbContext.Pacientes.Find(id);
     if (PacienteActual!= null)
    {
        DbContext.Remove(PacienteActual);
        await DbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.Run();
