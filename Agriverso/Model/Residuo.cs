namespace Agriverso.Model
{
    public class Residuo
    {

        public int ResiduoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoResiduoId { get; set; }
        public int EstadoId { get; set; }
        // Otros campos relevantes

        // Relación muchos a uno con TipoResiduo
        public virtual TipoResiduo TipoResiduo { get; set; }

        // Relación muchos a uno con Estado
        public virtual Estado Estado { get; set; }
    }
}
