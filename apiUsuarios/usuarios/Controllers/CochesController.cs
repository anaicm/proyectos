using Microsoft.AspNetCore.Mvc;

namespace apiUsuarios.data;

[ApiController]
[Route("[controller]")]

// UsuariosController=> nombre que le pongo yo a la clase 

public class CochesController : ControllerBase
{
    private readonly ILogger<UsuariosController> _logger;

    public CochesController(ILogger<UsuariosController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.Log(LogLevel.Information, "GetCoches:" + DateTime.Now);
        return Ok();
    }
}