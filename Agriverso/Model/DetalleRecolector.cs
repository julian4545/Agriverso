namespace Agriverso.Model
{
    public class DetalleRecolector
    {
        public int DetalleRecolectorId { get; set; }
        public int RecoleccionId { get; set; }
        public int ResiduoId { get; set; }
        public int Cantidad { get; set; }
        // Otros campos relevantes

        // Relación muchos a uno con Recolecciones
        public virtual Recoleccion Recoleccion { get; set; }

        // Relación muchos a uno con Residuos
        public virtual Residuo Residuo { get; set; }
    }
}
