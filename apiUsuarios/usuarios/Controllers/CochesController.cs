using apiUsuarios.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;

namespace apiUsuarios.data;

[ApiController]
[Route("[controller]")]

// CochesController=> nombre que le pongo yo a la clase 

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


    [HttpPost]//añadir
    public IActionResult Add(string color, string modelo)//parametros que entra son los campos que se han añadido a la tabla en la clase entidades
    {
        _cochesContext.Coches.Add(new entidades.Coche { Color = color, modelo = modelo });
        _cochesContext.SaveChanges();
        return Ok(_cochesContext.Coches);
    }
    [HttpPut]//=> Modificar
    //string? modelo => lleva la interrogacion para hacer opcional el campo que se va a modificar, es decir que no se tiene por que modificar ese
    //campo solo el que se quiera modificar, lo mismo se hace con todos los campos, de esta forma solo puedo cambiar un campo y lo demas se quede 
    //tal cual
    public async Task<ActionResult<Coche>> Put(Guid id, string? color, string? modelo)
    {
        var cocheActualizar = _cochesContext.Coches.Find(id);//Find(id) => se usa cuando el campo es clavle primaria, casa que voy a actualizar por id
        //var casa = _context.Casas.Where(c => c.id == id); => si el campo que se va a usar no es clave primaria

        if (cocheActualizar != null)//si la casa tiene algun valor, es decir existe
        {
            //actualiza los campos de la entidades/Casas
            //si no pongo esta condicion y cuando cambio un solo campo me lo actualiza con null, de esta forma deja el campo con el contenido 
            //que tiene
            if (color != null)
            {
                cocheActualizar.Color = color;//actualiza la casa con el color que me entra por parámetro
            }
            //si no pongo esta condicion y cuando cambio un solo campo me lo actualiza con null, de esta forma deja el campo con el contenido 
            //que tiene
            if (modelo != null)
            {
                cocheActualizar.modelo = modelo;//actualiza la casa con el modelo que me entra por parámetro
            }
        }
        _cochesContext.SaveChanges();
        return Ok();


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