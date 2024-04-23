using Microsoft.AspNetCore.Mvc;

namespace apiUsuarios.data;

[ApiController]
[Route("[controller]")]

// MueblesController=> nombre que le pongo yo a la clase 

public class MueblesController : ControllerBase
{
    private readonly ILogger<MueblesController> _logger;

    public MueblesController(ILogger<MueblesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.Log(LogLevel.Information, "GetMuebles:" + DateTime.Now);
        return Ok();
    }
}