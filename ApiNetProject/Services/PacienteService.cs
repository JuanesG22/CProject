using webapi.Models;
namespace webapi.Services;

public class PacientesService : IPacientesServices
{
    PacientesContext context;

    public PacientesService(PacientesContext  dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Paciente> Get()
    {
        return context.Pacientes;
    }
    public async Task Save(Paciente paciente)
    {
        context.Add(paciente);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid PacienteId,Paciente paciente)
    {
        var pacienteActual = context.Pacientes.Find(PacienteId);
        if (pacienteActual != null)
        {
            pacienteActual.Nombre = paciente.Nombre;
            pacienteActual.Apellido = paciente.Apellido;
            pacienteActual.DocumentoPaciente = paciente.DocumentoPaciente;
            await context.SaveChangesAsync();
        } 
    }
    public async Task Delete(Guid PacienteId)
    {
        var pacienteActual = context.Pacientes.Find(PacienteId);
        if (pacienteActual != null)
        {
            context.Remove(pacienteActual);
            await context.SaveChangesAsync();
        }
        
    }
}

public interface IPacientesServices
{
    IEnumerable<Paciente> Get();
    Task Save(Paciente paciente);
    Task Update(Guid PacienteId,Paciente paciente);
    Task Delete(Guid PacienteId);
}