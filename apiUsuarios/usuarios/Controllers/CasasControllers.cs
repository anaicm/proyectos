using apiUsuarios.entidades;
using apiUsuarios.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Abstractions;

namespace apiUsuarios.Controllers;

[ApiController]
[Route("[controller]")]

// CasasController=> nombre que le pongo yo a la clase 

public class CasasController : ControllerBase
{
    private readonly ILogger<CasasController> _logger;
    private readonly CasasContext _context;

    public CasasController(ILogger<CasasController> logger, CasasContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("{id}")] // Especificamos que este endpoint espera un parámetro llamado "id" en la URL
    public async Task<ActionResult<Casa>> Get(Guid id)//Casa=> nombre de la clase entidades/Casas
    {
        var casa = await _context.Casas.FindAsync(id);//Casas=> nombre de la función get y set en la clase data/CasasContext
        if (casa == null)
        {
            return NotFound();
        }
        return casa;
    }
    [HttpGet]//trae toda la tabla
    public IActionResult GetCasas()
    {
        _logger.LogInformation("GetCasas: {time}", DateTime.Now);
        var casas = _context.Casas.ToList(); // Obtener todas las casas
        return Ok(casas);
    }

    [HttpPost]//=> Añadir 
    public async Task<ActionResult<Casa>> Post(Casa casa)
    {
        _context.Casas.Add(casa);//casa => parametro que entra 
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCasas), new { casa.id }, casa);//el parametro que entra usa el campo "id" que se encuentra en la entidades/Casas
    }

    [HttpPut]//=> Modificar
    //string? modelo => lleva la interrogacion para hacer opcional el campo que se va a modificar, es decir que no se tiene por que modificar ese
    //campo solo el que se quiera modificar, lo mismo se hace con todos los campos, de esta forma solo puedo cambiar un campo y lo demas se quede 
    //tal cual
    public async Task<ActionResult<Casa>> Put(Guid id, string? color, string? modelo)
    {
        var casaActualizar = _context.Casas.Find(id);//Find(id) => se usa cuando el campo es clavle primaria, casa que voy a actualizar por id
        //var casa = _context.Casas.Where(c => c.id == id); => si el campo que se va a usar no es clave primaria

        if(casaActualizar != null)//si la casa tiene algun valor, es decir existe
        {
            //actualiza los campos de la entidades/Casas
            //si no pongo esta condicion y cuando cambio un solo campo me lo actualiza con null, de esta forma deja el campo con el contenido 
            //que tiene
            if (color != null)
            {
                casaActualizar.Color = color;//actualiza la casa con el color que me entra por parámetro
            }
            //si no pongo esta condicion y cuando cambio un solo campo me lo actualiza con null, de esta forma deja el campo con el contenido 
            //que tiene
            if(modelo != null) { 
                casaActualizar.modelo = modelo;//actualiza la casa con el modelo que me entra por parámetro
            }
        }
        _context.SaveChanges();
        return Ok();

       
    }
    [HttpDelete]//=> Borrar
    public async Task<ActionResult<Casa>> Delete(Guid id)//Casa=> nombre de la clase entidades/Casas
    {
        var casa = await _context.Casas.FindAsync(id);//Casas=> nombre que se le da a la tabla en la clase data/CasasContext
        if (casa == null)
        {
            return NotFound();
        }

        _context.Casas.Remove(casa);//Casas=> nombre que se le da a la tabla en la clase data/CasasContext
        await _context.SaveChangesAsync();

        return casa;
    }
}