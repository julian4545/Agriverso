namespace Agriverso.Model
{
    public class Recolector
    {

        public int RecolectorId { get; set; }
        public int GranjeroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        // Otros campos relevantes

        // Relación muchos a uno con Granjeros
        public virtual Granjero Granjero { get; set; }

        // Relación uno a muchos con Recolecciones
        public virtual ICollection<Recoleccion> Recolecciones { get; set; }
    }
}
