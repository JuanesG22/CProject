namespace ApiNetProject.Services;
using ApiNetProject.Models;

public class PacientesService : IPacientesService
{
    PacientesContext context;
    public  PacientesService(PacientesContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Paciente> Get()
    {
        return context.Pacientes;
    }
}

public interface IPacientesService
{
    IEnumerable<Paciente> Get();
}