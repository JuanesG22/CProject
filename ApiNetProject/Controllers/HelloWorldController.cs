using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    public HelloWorldController(IHelloWorldService helloworld)
    {
        helloWorldService = helloworld;
    }
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}