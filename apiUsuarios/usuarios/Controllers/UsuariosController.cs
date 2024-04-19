using apiUsuarios.data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apiUsuarios.data;

[ApiController]
[Route("[controller]")]

// UsuariosController=> nombre que le pongo yo a la clase 
//: ControllerBase => hereda

public class UsuariosController : ControllerBase
{
    private readonly ILogger<UsuariosController> _logger;
    private readonly UsersContext _usersContext;
    //userManager => Realiza el CRUD de los usuarios
    private readonly UserManager<IdentityUser> _userManager;//usuarios

    public UsuariosController(ILogger<UsuariosController> logger, UsersContext usersContext, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _usersContext = usersContext;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.Log(LogLevel.Information, "GetUsers:" + DateTime.Now);
        foreach(var user in _usersContext.Users)
        {

        }
        return Ok(_usersContext.Users);
    }
    [HttpPost]//añadir registro
    public async Task<ActionResult> Add(string username, string password)
    {
        // var authenticatedUserName = HttpContext.User.Identity.Name; => obtiene el nombre del usuario por la cookies
        // var user = _userContext.FindByNameAsync(authenticatedUserName); => Devuelve el usuario en el que coincide el nombre

        var user = new IdentityUser
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
