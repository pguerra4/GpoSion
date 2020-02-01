namespace GpoSion.API.Models
{
    public class ProduccionNumeroParte
    {
        public int ProduccionNumeroParteId { get; set; }
        public int ProduccionId { get; set; }
        public virtual Produccion Produccion { get; set; }

        public string NoParte { get; set; }
        public virtual NumeroParte NumeroParte { get; set; }

        public int Piezas { get; set; }
        public int Scrap { get; set; }

    }
}