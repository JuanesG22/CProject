using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;
namespace webapi.Controllers;


[Route("api/[controller]")]
public class EmpleadoController: ControllerBase
{
    IEmpleadoService empleadoService;
    public EmpleadoController(IEmpleadoService service)
    {
        empleadoService = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(empleadoService.Get());

    }

    [HttpPost]
    public IActionResult Post([FromBody] Empleado empleado)
    {
        empleadoService.Save(empleado);
        return Ok();

    }

    [HttpPut("{EmpleadoId}")]
    public IActionResult Put(Guid EmpleadoId,[FromBody] Empleado empleado)
    {
        empleadoService.Update(EmpleadoId,empleado);
        return Ok();

    }

    [HttpDelete("{EmpleadoId}")]
    public IActionResult Delete(Guid EmpleadoId)
    {
        empleadoService.Delete(EmpleadoId);
        return Ok();

    }
}