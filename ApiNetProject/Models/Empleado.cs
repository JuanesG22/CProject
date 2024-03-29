using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Empleado
{
    //[Key]
    public Guid EmpleadoId {get;set;}
    //[Required]
    //[MaxLength(100)]
    public string Nombre {get;set;}
    //[MaxLength(100)]
    public string Apellido {get;set;}
    //[Required]
    public int DocumentoEmpleado{get;set;}
    public string Especialidad {get;set;}
    public string ContraseñaEmpleado {get;set;}
    public DateTime FechadeContratacion {get;set;}
    public string TipodeContrato {get;set;}
    [JsonIgnore]
    public virtual ICollection<Paciente>? Pacientes{get;set;}
    public int ControlPacienteporDia {get; set;}

}