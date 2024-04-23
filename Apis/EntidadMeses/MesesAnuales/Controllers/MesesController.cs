//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Azure;
//using Microsoft.IdentityModel.Abstractions;
using MesesAnuales.DataContext;
using MesesAnuales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MesesAnuales.Controllers;

[ApiController]
[Route("[controller]")]
public class MesesController : ControllerBase
{
    private readonly ILogger<MesesController> _logger;
    private readonly MesesContext _context;

    public MesesController(ILogger<MesesController> logger, MesesContext context)
    {
        _logger = logger;
        _context = context;
    }

  
    [HttpGet]//trae toda la tabla
    public IActionResult GetCasas()
    {
        _logger.LogInformation("GetCasas: {time}", DateTime.Now);
        var mes = _context.Meses.ToList(); // Obtener todas las casas
        return Ok(mes);
    }

  
}