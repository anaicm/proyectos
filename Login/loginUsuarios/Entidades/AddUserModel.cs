namespace loginUsuarios.Entidades
{
    public class AddUserModel//es el parámetro que entra en el metodo añadir usuario y tienen todos los parámetros necesarios que se 
        //ponen dentro de la clase.
    {
        //son todos los parametros que entra en el método para añadir
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}
