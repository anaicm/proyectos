using apiUsuarios.entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apiUsuarios.data;

[ApiController]
[Route("[controller]")]

// UsuariosController=> nombre que le pongo yo a la clase 
//: ControllerBase => hereda

public class UsuariosController : ControllerBase
{
    //Ilogger => normalmente esta en todos los controllers, se usa para guardar trazas o logs que guarda información, como es 
    //que usuario ha realizado la petinción, ip, al método al que entra y con que parámetros o la fecha entre otros.
    private readonly ILogger<UsuariosController> _logger;
    //userManager => Realiza el CRUD de los usuarios
    //como se ha configurado el user manger en program con la clase Usuario que tiene los campos añidos, es de tipo "Usuario" clase 
    //con los campos 
    private readonly UserManager<Usuario> _userManager;//usuarios

    public UsuariosController(ILogger<UsuariosController> logger, UserManager<Usuario> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //_logger => es donde hago las peticiones para guardar las trazas, en este caso es de tipo informacion y da el dia y la hora
        //siempre es un String.
        _logger.Log(LogLevel.Information, "GetUsers:" + DateTime.Now);
        var users = _userManager.Users;//guarda todos los registos que hay en la tabla usuarios (array de usuarios)
        return Ok(users);
    }
    [HttpPost]//añadir registro
    public async Task<ActionResult> Add(string username, string password)
    {
        // var authenticatedUserName = HttpContext.User.Identity.Name; => obtiene el nombre del usuario por la cookies
        // var user = _userContext.FindByNameAsync(authenticatedUserName); => Devuelve el usuario en el que coincide el nombre

        var user = new Usuario
        {
            UserName = username,
            Email = username
        };
        if (!string.IsNullOrEmpty(password))
        {
            //CreateAsync() => Crea el usuario y realiza el hash a la password
            var result = await _userManager.CreateAsync(user, password);//CreateAsync()=> comprueba las reglas de la contraseña 
            if (result.Succeeded)
            {
                return Ok(user); // Devuelve un Ok del elemento
            }
            else
            {
                // Manejar errores aquí si es necesario
                return BadRequest(result.Errors);
            }
        }
        return BadRequest();
    }

    [HttpPut]
    public IActionResult Put()
    {
        return null;
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return null;
    }
}
