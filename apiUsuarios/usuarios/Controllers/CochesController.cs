using apiUsuarios.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;

namespace apiUsuarios.data;

[ApiController]
[Route("[controller]")]

// MueblesController=> nombre que le pongo yo a la clase 

public class CochesController : ControllerBase
{
    private readonly ILogger<CochesController> _logger;
    private readonly CochesContext _cochesContext;

    public CochesController(ILogger<CochesController> logger, CochesContext cochesContext)
    {
        _logger = logger;
        _cochesContext = cochesContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.Log(LogLevel.Information, "GetCoches:" + DateTime.Now);
        return Ok(_cochesContext.Coches);
    }


    [HttpPost]
    public IActionResult Add(string color, string modelo)
    {
        _cochesContext.Coches.Add(new entidades.Coche { Color = color, modelo = modelo });
        _cochesContext.SaveChanges();
        return Ok(_cochesContext.Coches);
    }

    [HttpDelete]//=> Borrar
    public async Task<ActionResult<Coche>> Delete(Guid id)//Casa=> nombre de la clase entidades/Coche.cs
    {
        var coche = await _cochesContext.Coches.FindAsync(id);//Coches=> nombre que se le da a la tabla en la clase data/CochesContext
        if (coche == null)
        {
            return NotFound();
        }

        _cochesContext.Coches.Remove(coche);//Coches=> nombre que se le da a la tabla en la clase data/CochesContext
        await _cochesContext.SaveChangesAsync();

        return coche;
    }
}