using loginUsuarios.entidades;
using loginUsuarios.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace loginUsuarios.Services
{
    public class UsuariosService : IUsuariosService
    {
        //userManager => Realiza el CRUD de los usuarios
        //como se ha configurado el user manger en program con la clase Usuario que tiene los campos añidos, es de tipo "Usuario" clase 
        //con los campos 
        private readonly UserManager<Usuario> _userManager;//usuarios 
        private readonly SignInManager<Usuario> _signInManager;//para el login

        //constructor
        public UsuariosService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //leer los usuarios
        public List<Usuario> GetUsuarios()
        {
            return _userManager.Users.ToList();
        }

        //añadir usuario
        public async Task<IdentityResult> AddUsuario(Usuario user, string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                //CreateAsync() => Crea el usuario y realiza el hash a la password
                var result = await _userManager.CreateAsync(user, password);//CreateAsync()=> comprueba las reglas de la contraseña 
                return result;
            }
            return null;
        }
        //borrar usuario
        public async Task<IdentityResult> BorrarUsuario(Guid id)
        {
            // Encuentra el usuario por su Id
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                // Borra el usuario
                var result = await _userManager.DeleteAsync(user);
                return result;
            }
            else
            {
                // Maneja el caso en que el usuario no se encuentre
                // Puedes lanzar una excepción o devolver un IdentityResult personalizado según tu lógica de negocio
                return IdentityResult.Failed(new IdentityError { Description = $"No se pudo encontrar un usuario con el Id {id}" });
            }
        }

        public Task<SignInResult> LoginUsuario(LoginModel loginModel)//método paraa realizar el login
        {
           var result = _signInManager.PasswordSignInAsync(loginModel.username, loginModel.password, true, false);
            return result;
        }
    }
}
