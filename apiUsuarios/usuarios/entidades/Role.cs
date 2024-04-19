using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace apiUsuarios.entidades;//donde se encuentra la clase (RUTA)
//usuario es la entidad (tabla ) con los campos, por defecto trae los campos, nombre que yo le pongo a la tabla
//: IdentityRole => hereda y pone los id con guid si quiere de int se pone <int> o lo que sea
public class Role : IdentityRole<Guid>

    {
    //campos añadidos a la tabla que da Identity 
    [MaxLength(250)]
        public string Description { get; set; }// los String da errores nulables y por eso da ese error (no se le hace caso)

    }

