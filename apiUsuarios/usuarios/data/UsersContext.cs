//ACCESO A BASE DE DATOS

using apiUsuarios.entidades;//todo lo que hay en la carpeta entidades ya puedo usarlo en esta clase como 'Role' y 'Usuario'

using Microsoft.AspNetCore.Identity;// framework para la gestion de usuarios con identity
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;//framework que accede a la base de datos 
using Microsoft.EntityFrameworkCore;

namespace apiUsuarios.data;//uso de todo el proyecto (raiz)

//public class UsersContext : IdentityDbContext => si solo se pone sin clases por defecto Identity creara su clases.

//UsersContext => nombre que se da a la clase 
//IdentityDbContext => Hereda de Identity cuando es el login, cuando no es login hereda de : DbContext
//<Usuario, Role, Guid> => 
// - Usuarios => es la clase usuarios que son los que da .NET mas los campos añadidos en la clase.
// hay usarla para que la clase sepa donde está "using apiUsuarios.entidades;"
// - Role => es la clase para los Roles que son los que da .NET mas los campos añadidos en la clase.
// hay usarla para que la clase sepa donde está "using apiUsuarios.entidades;"
// - Guid => Autogenera los id en formato guid que siempre es unico, por lo que en la clase Usuario tambien se tiene que poner.
//podria se int, etc.
public class UsersContext : IdentityDbContext<Usuario, Role, Guid>
{
    //constructor de "UsersContext", siempre es igual solo cambia el nombre de la clase 
    //base => es la herencia como 'super' en JAVA
    public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //lo que hace estas líneas es => sobreescribe la migración inicial cambiando el nombre de las tablas por defecto.
        modelBuilder.Entity<Usuario>().ToTable("Users");//le estoy diciendo que la tabla "Usuario" se va a llamar "Users"
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

    }
}
