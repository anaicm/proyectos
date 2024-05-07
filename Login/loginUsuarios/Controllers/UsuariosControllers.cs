using Microsoft.AspNetCore.Mvc;
using loginUsuarios.entidades;
using Microsoft.AspNetCore.Identity;
using loginUsuarios.Services;
using System.Linq.Expressions;
using loginUsuarios.Entidades;
using Microsoft.AspNetCore.Authorization;

namespace loginUsuarios.Controllers;

[Authorize]// todo el controller estará protegido por autenticacion, al intentar realizar un método me devuelve un 401
[ApiController]
[Route("[controller]")]
// UsuariosController=> nombre que le pongo yo a la clase 
//: ControllerBase => hereda
public class UsuariosController : ControllerBase
{
//Declaración de variables que se inicializan en el constructor
 //--*Ilogger => normalmente esta en todos los controllers, se usa para guardar trazas o logs que guarda información, como es 
 //--que usuario ha realizado la petinción, ip, al método al que entra y con que parámetros o la fecha entre otros.
    private readonly ILogger<UsuariosController> _logger;
    private readonly IUsuariosService _usuariosService;

// el constructor tiene que tener el mismo nombre que la clase controllers "UsuariosController"
    public UsuariosController(ILogger<UsuariosController> logger, IUsuariosService usuariosService)
    {
        _logger = logger;
        _usuariosService = usuariosService;        
    }
    //Métodos
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        //_logger => es donde hago las peticiones para guardar las trazas, en este caso es de tipo informacion y da el dia y la hora
        //siempre es un String.
        _logger.Log(LogLevel.Information, "GetUsers:" + DateTime.Now);
        var users = _usuariosService.GetUsuarios();
        return Ok(users);
    }
    [HttpPost]//añadir registro
    public async Task<ActionResult> Add(AddUserModel addUserModel)
    {
        //los parametros son los campos que se van a pedir para la creacion de un nuevo usuario, si se pasan directamente se hacen por URL
        //pero es mejor hacerlo con body, se crea una entidad (Entidades/AddUserModel.cs), en esa clase se realizan todos los parámetros
        var user = new Usuario//se crea el usuario para que el servicio
        {
            //username=>son los public de la entidad (Entidades/AddUserModel.cs), addUserModel => con el parámetro del método
            UserName = addUserModel.username,
            Email = addUserModel.username,
            Nombre = addUserModel.nombre,
            Apellido = addUserModel.apellido
        };
        // guarda si se ha creado el nuevo usuario 
        var result = await _usuariosService.AddUsuario(user,addUserModel.password);
        if (result != null)
        {
            if (result.Succeeded)//si se ha creado el nuevo usuario 
            {
                return Ok(user); // Devuelve un Ok del elemento
            }
            else// si no se ha creado el nuevo usuario 
            {
                // Manejar errores aquí si es necesario
                return BadRequest(result.Errors);
            }
        }
        return BadRequest();// devuelve un 400 en caso de error 
    }
    //Método para eliminar usuario 
    [HttpDelete("{id}")] // Ruta para borrar un usuario por su Id
    public async Task<ActionResult> Borrar(Guid id)
    {
        // Intenta borrar el usuario utilizando el servicio
        var result = await _usuariosService.BorrarUsuario(id);

        if (result != null && result.Succeeded)
        {
            // Si se borra exitosamente, devuelve un Ok con un mensaje
            return Ok("Usuario borrado exitosamente.");
        }
        else
        {
            // Maneja el caso en que no se pueda borrar el usuario
            // Devuelve un BadRequest con los errores proporcionados por el servicio
            return BadRequest(result.Errors);
        }
    }

    [AllowAnonymous]//quita la autorización 401 para ese método en concreto
    //método para la realizacion del login
    [HttpPost("login")] // Ruta para iniciar sesión de un usuario
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        // Intenta iniciar sesión utilizando el servicio
        var result = await _usuariosService.LoginUsuario(loginModel);

        if (result.Succeeded)
        {
            // Si el inicio de sesión es exitoso, devuelve un Ok con un mensaje
            return Ok("Inicio de sesión exitoso.");
        }
        else
        {
            // Si el inicio de sesión falla, devuelve un BadRequest con un mensaje de error
            return BadRequest("Inicio de sesión fallido. Por favor, verifica tus credenciales.");
        }
    }
}
