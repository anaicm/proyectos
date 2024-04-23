//ACCESO A BASE DE DATOS

using MesesAnuales.Entidades;//todo lo que hay en la carpeta entidades ya puedo usarlo en esta clase como 'Role' y 'Usuario'

//using Microsoft.AspNetCore.Identity;// framework para la gestion de usuarios con identity
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;//framework que accede a la base de datos 
using Microsoft.EntityFrameworkCore;

namespace MesesAnuales.DataContext;//uso de todo el proyecto (raiz)

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
public class MesesContext : DbContext
{
    //constructor de "UsersContext", siempre es igual solo cambia el nombre de la clase 
    //base => es la herencia como 'super' en JAVA
    //<MesesContext> => nombre de la clase 
    public MesesContext(DbContextOptions<MesesContext> options) : base(options){ }


    //Messa => es la clase que se encuentra en Entidades/Mes.cs
    //Meses => es la funcion para los get y set del controllers
    public DbSet<Mes> Meses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //le estoy diciendo que la tabla "Casa" se va a llamar "Casa"
        modelBuilder.Entity<Mes>().ToTable("Mes");
    }
}
