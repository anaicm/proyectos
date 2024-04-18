using System.Runtime.Intrinsics.X86;

namespace apiUsuarios.entidades{
    public class Usuario{
        //con prop tabulador realiza el método directamente
        //entity framework por defeto toma el id como una clave primaria
        public int? Id { get; set; } //id de la base de datos, con la interrogación se puede hacer que sea null, de este modo ya son opcionales
        //puede ser null, esto se arregla con string.Empty
        //para incializarlo en el momento con public request...sigue la función
        public string Nombre{ get; set; }=string.Empty;
        public string Descripcion{ get; set; }=string.Empty;
    }
}