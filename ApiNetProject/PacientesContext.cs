using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class PacientesContext: DbContext
{
    public DbSet<Empleado> Empleados{get;set;}  
    public DbSet<Paciente> Pacientes{get;set;}
    public PacientesContext(DbContextOptions<PacientesContext> options) :base(options){ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Empleado> EmpleadosInit = new List<Empleado>();

        EmpleadosInit.Add(new Empleado() {EmpleadoId = Guid.Parse("E7AF78EE36CD4ED2AB23BFC80706F398"), Nombre = "Julian Andres", Apellido = "Ramirez Balanta", 
        ContraseñaEmpleado = "123456", DocumentoEmpleado = 1094281844, Especialidad = "Medico Cirujano", FechadeContratacion = DateTime.Now, TipodeContrato = "Termino Indefinido",ControlPacienteporDia = 2});
        EmpleadosInit.Add(new Empleado() {EmpleadoId = Guid.Parse("265E0C8C13D54A4EA7D4396058099E78"), Nombre = "David", Apellido = "Alzate Giraldo", 
        ContraseñaEmpleado = "123457", DocumentoEmpleado = 1097839411, Especialidad = "Pediatria", FechadeContratacion = DateTime.Now, TipodeContrato = "Termino Indefinido",ControlPacienteporDia = 1});
        
        modelBuilder.Entity<Empleado>(Empleado =>{
            Empleado.ToTable("Empleado");
            Empleado.HasKey(p => p.EmpleadoId);
            Empleado.Property(p => p.Nombre).HasMaxLength(150);
            Empleado.Property(p => p.DocumentoEmpleado).IsRequired();
            Empleado.Property(p => p.ControlPacienteporDia);
            Empleado.HasData(EmpleadosInit);
        });

        List<Paciente> PacientesInit = new List<Paciente>();

        PacientesInit.Add(new Paciente() {PacienteId= Guid.Parse("E7AF78EE36CD4ED2AB23BFC80706F397"), Nombre = "Antonio", Apellido = "Margareti", DocumentoPaciente = 1094829382
        , FechadeIngreso = DateTime.Now, DescripcionCaso = "Accidente laboral en donde presenta multiples heridas en la pierna causadas por un ventilador industrial", 
        EmpleadoId = Guid.Parse("E7AF78EE36CD4ED2AB23BFC80706F398"), PrioridadPaciente = Prioridad.Alta, Edad = 35}); 

        PacientesInit.Add(new Paciente() {PacienteId= Guid.Parse("E7AF78EE36CD4ED2AB23BFC80706F399"), Nombre = "Santiago", Apellido = "Solari", DocumentoPaciente = 1013529382
        , FechadeIngreso = DateTime.Now, DescripcionCaso = "Intoxicacion por leche en polvo vencida",Edad = 3, 
        EmpleadoId = Guid.Parse("265E0C8C13D54A4EA7D4396058099E78"), PrioridadPaciente = Prioridad.Media}); 

        modelBuilder.Entity<Paciente>(Paciente => {
            Paciente.ToTable("Paciente");
            Paciente.HasKey(p => p.PacienteId);
            Paciente.HasOne(p => p.Empleado).WithMany(p => p.Pacientes).HasForeignKey(p => p.EmpleadoId);
            Paciente.Property(p => p.Nombre).HasMaxLength(150);
            Paciente.Property(p => p.DocumentoPaciente).IsRequired();
            Paciente.Property(p => p.FechadeIngreso).IsRequired();
            Paciente.Property(p => p.Edad).IsRequired();
            Paciente.HasData(PacientesInit);

        });
    }
} 