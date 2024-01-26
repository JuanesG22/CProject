using webapi.Models;
namespace webapi.Services;

public class EmpleadoService: IEmpleadoService
{
    PacientesContext context;
    public EmpleadoService(PacientesContext  dbcontext)
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
    public async Task Update(Guid EmpleadoId,Empleado empleado)
    {
        var empleadoActual = context.Empleados.Find(EmpleadoId);
        if (empleadoActual != null)
        {
            empleadoActual.Nombre = empleado.Nombre;
            empleadoActual.Apellido = empleado.Apellido;
            empleadoActual.DocumentoEmpleado = empleado.DocumentoEmpleado;
            await context.SaveChangesAsync();
        }
        
    }
    public async Task Delete(Guid EmpleadoId)
    {
        var empleadoActual = context.Empleados.Find(EmpleadoId);
        if (empleadoActual != null)
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
    Task Update(Guid EmpleadoId,Empleado empleado);
    Task Delete(Guid EmpleadoId);
}