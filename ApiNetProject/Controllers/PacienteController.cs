using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;
namespace webapi.Controllers;

[Route("api/[controller]")]

public class PacienteController: ControllerBase
{
    IPacientesService pacientesService;
    public PacienteController(IPacientesService service)
    {
        pacientesService = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(pacientesService.Get());

    }

    [HttpPost]
    public IActionResult Post([FromBody] Paciente paciente)
    {
        pacientesService.Save(paciente);
        return Ok();

    }

    [HttpPut("{PacienteId}")]
    public IActionResult Put(Guid PacienteId,[FromBody] Paciente paciente)
    {
        pacientesService.Update(PacienteId,paciente);
        return Ok();

    }

    [HttpDelete("{PacienteId}")]
    public IActionResult Delete(Guid PacienteId)
    {
        pacientesService.Delete(PacienteId);
        return Ok();

    }
}