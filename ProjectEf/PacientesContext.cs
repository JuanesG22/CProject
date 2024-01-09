using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class PacientesContext: DbContext
{
    public DbSet<Empleado> Empleados{get;set;}  
    public DbSet<Paciente> Pacientes{get;set;}
    public PacientesContext(DbContextOptions<PacientesContext> options) :base(options){ }
} 