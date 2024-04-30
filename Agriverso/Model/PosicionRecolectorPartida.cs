namespace Agriverso.Model
{
    public class PosicionRecolectorPartida
    {
        public int PosicionRecolectorPartidaId { get; set; }
        public int PartidaRecolectorId { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        // Otros campos relevantes

        // Relación muchos a uno con PartidaRecolector
        public virtual PartidaRecolector PartidaRecolector { get; set; }
    }
}
