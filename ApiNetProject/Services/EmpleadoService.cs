namespace ApiNetProject.Services;
using ApiNetProject.Models;
public class EmpleadoService : IEmpleadoService
{  
    PacientesContext context;
    public  EmpleadoService(PacientesContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Empleado> Get()
    {
        return context.Empleados;
    }
    public async Task Save(Empleado empleado)
    {
        context.Add(empleado);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Empleado empleado)
    {
        var empleadoActual = context.Empleados.Find(id);
        if(empleadoActual != null)
        {
            empleadoActual.Nombre = empleado.Nombre;
            empleadoActual.Especialidad = empleado.Especialidad;
            empleadoActual.DocumentoEmpleado = empleado.DocumentoEmpleado;

            await context.SaveChangesAsync();
        }

    }

    public async Task Delete(Guid id)
    {
        var empleadoActual = context.Empleados.Find(id);
        if(empleadoActual != null)
        {
            context.Remove(empleadoActual);

            await context.SaveChangesAsync();
        }

    }
}

public interface IEmpleadoService
{
    IEnumerable<Empleado> Get();
    Task Save(Empleado empleado);
    Task Update(Guid id,Empleado empleado);
    Task Delete(Guid id);
}