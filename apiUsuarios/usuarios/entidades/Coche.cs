//CLASE PARA AÑADIR CAMPOS 

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace apiUsuarios.entidades//donde se encuentra la clase (RUTA)
{

    //no hereda de nada 
    public class Coche //se pasa en CochesContext.cs
    {
        [Key] 
        public Guid id { get; set; }

        //campos añadidos a la tabla  
        public string? Color { get; set; }

        public string? modelo { get; set; }

    }
}