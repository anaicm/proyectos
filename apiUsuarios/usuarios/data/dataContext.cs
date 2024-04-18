using Microsoft.EntityFrameworkCore;
using apiUsuarios.entidades;

namespace apiUsuarios.data{//si te fijas son las carpetas donde se encuentra
    
    //DataContext hereda de DbContext, la herencia se hace con los dos puntitos
    //DbContext, no lo reconoce
    public class DataContext : DbContext{
        internal object Usuarios;
        
        //Se agrega el constructor poner ctor y tabulador (lo crea directamente)
        //DbContextOptions contexto en el que nos encontramos (DbContext)
        //<DataContext>El tipo que recibe por paárametro (Es la clase)
        //option variable
        //:base(options)pasa la variable a la clase base 
        //La clase base es la que va ha realizar la implementación (realiza el trabajo)

        public DataContext(DbContextOptions<DataContext>options):base(options)
        {  
            Database.EnsureCreated();
        }
        //Creara una BD del producto que estoy realizando, se llamará producto de tipo <producto>
        //el nombre que se le ponga ese será el nombre de la tabla, en este caso se llama Producto
        
        public DbSet<Usuario> Usuario {get; set;}
    }
}