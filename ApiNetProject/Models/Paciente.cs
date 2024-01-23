using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webapi.Models;

public class Paciente
{   
    //[Key]
    public Guid PacienteId{get;set;}
    //[ForeignKey("CategoriaId")]
    public Guid EmpleadoId{get;set;}
    //[MaxLength(100)]
    public string Nombre {get;set;}
    public string Apellido {get;set;}
    public int Edad {get;set;}
    //[Required]
    public int DocumentoPaciente {get;set;}
    //[Required]
    public DateTime FechadeIngreso {get;set;}
    public string DescripcionCaso {get;set;}
    public Prioridad PrioridadPaciente{get;set;}
    public virtual Empleado Empleado{get;set;}

}

public enum Prioridad
{   
    Baja,
    Media,
    Alta
}