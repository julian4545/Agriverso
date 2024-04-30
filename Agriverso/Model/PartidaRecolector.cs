namespace Agriverso.Model
{
    public class PartidaRecolector
    {
        public int PartidaRecolectorId { get; set; }
        public int RecolectorId { get; set; }
        // Otros campos relevantes

        // Relación muchos a uno con Recolectores
        public virtual Recolector Recolector { get; set; }

        // Relación uno a muchos con PosicionesRecolectorPartida
        public virtual ICollection<PosicionRecolectorPartida> PosicionesRecolectorPartida { get; set; }
    }
}
