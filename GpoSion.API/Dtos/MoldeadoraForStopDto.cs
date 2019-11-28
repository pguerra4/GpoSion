namespace GpoSion.API.Dtos
{
    public class MoldeadoraForStopDto
    {
        public int MoldeadoraId { get; set; }

        public string Movimiento { get; set; }

        public string Observaciones { get; set; }

        public int? MotivoTiempoMuertoId { get; set; }
    }
}