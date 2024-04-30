namespace Agriverso.Model
{
    public class Recoleccion
    {

        public int RecoleccionId { get; set; }
        public int RecolectorId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        // Otros campos relevantes

        // Relación muchos a uno con Recolectores
        public virtual Recolector Recolector { get; set; }

        // Relación uno a muchos con DetalleRecolector
        public virtual ICollection<DetalleRecolector> DetallesRecolector { get; set; }
    }
}
