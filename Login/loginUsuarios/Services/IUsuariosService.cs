using loginUsuarios.entidades;
using loginUsuarios.Entidades;
using Microsoft.AspNetCore.Identity;

namespace loginUsuarios.Services

    //archivo para las interfaces
{
    public interface IUsuariosService
    {
        //List=> esta disponible directamente de la libreria
        public List<Usuario> GetUsuarios();//leer los usuarios (tabla)
        public Task<IdentityResult> AddUsuario(Usuario user, string password); //añadir usuarios (fila)
        public Task<IdentityResult> BorrarUsuario(Guid id); //borrar usuario (fila)

     
        public Task<SignInResult> LoginUsuario(LoginModel loginModel); //logar usuario 
        //LoginModel loginModel=> entidad que contiene los parámetros (Entidades/LoginModel.cs)
    }
}
