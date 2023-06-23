namespace UserITApp.Entities
{
    public class Aplicacion
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Aplicacion(string id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}