//CLASE PARA AÑADIR CAMPOS 

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace loginUsuarios.entidades//donde se encuentra la clase (RUTA)
{
    // solo me quedo con los campos que me interesa de la tabla por defecto que me da identity para el añadir usuario

    //usuario es la entidad (tabla ) con los campos, por defecto trae los campos, nombre que yo le pongo a la tabla
    //: IdentityUser => hereda y pone los id con guid si quiere de int se pone <int> o lo que sea
    public class Usuario : IdentityUser<Guid>
    {
        //campos añadidos a la tabla que da Identity 
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

    }
}