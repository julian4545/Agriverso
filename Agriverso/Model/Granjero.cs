namespace Agriverso.Model
{
    public class Granjero
    {
        public int GranjeroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        // Otros campos relevantes

        // Relación uno a muchos con Recolectores
        public virtual ICollection<Recolector> Recolectores { get; set; }
    }
}
