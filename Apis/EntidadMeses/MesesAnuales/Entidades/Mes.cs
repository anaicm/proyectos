//CLASE PARA AÑADIR CAMPOS 

//using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MesesAnuales.Entidades//donde se encuentra la clase (RUTA)
{

    //no hereda de nada 
    public class Mes //se pasa en CochesContext.cs
    {
        [Key] 
        public Guid id { get; set; }

        //campos añadidos a la tabla  
        public string? Nombre { get; set; }

        public string? Dias { get; set; }
        
        public string? Semanas { get; set; }

    }
}