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
public class CasasContext : DbContext
{
    //constructor de "UsersContext", siempre es igual solo cambia el nombre de la clase 
    //base => es la herencia como 'super' en JAVA
    public CasasContext(DbContextOptions<CasasContext> options) : base(options) { }


    //Casa => es la clase que se encuentra en Casas.cs
    public DbSet<Casa> Casas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Casa>().ToTable("Casa");//le estoy diciendo que la tabla "Casa" se va a llamar "Casa"
    }
}
