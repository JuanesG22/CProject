using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class PacientesContext: DbContext
{
    public DbSet<Empleado> Empleados{get;set;}  
    public DbSet<Paciente> Pacientes{get;set;}
    public PacientesContext(DbContextOptions<PacientesContext> options) :base(options){ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(Empleado =>{
            Empleado.ToTable("Categoria");
            Empleado.HasKey(p => p.EmpleadoId);
            Empleado.Property(p => p.Nombre).HasMaxLength(150);
            Empleado.Property(p => p.DocumentoEmpleado).IsRequired();
        });
        modelBuilder.Entity<Paciente>(Paciente => {
            Paciente.ToTable("Paciente");
            Paciente.HasKey(p => p.PacienteId);
            Paciente.HasOne(p => p.Empleado).WithMany(p => p.Pacientes).HasForeignKey(p => p.EmpleadoId);
            Paciente.Property(p => p.Nombre).HasMaxLength(150);
            Paciente.Property(p => p.DocumentoPaciente).IsRequired();
            Paciente.Property(p => p.FechadeIngreso).IsRequired();

        });
    }
} 