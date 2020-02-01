namespace GpoSion.API.Dtos
{
    public class RetornoMaterialToEditDto
    {
        public int MovimientoMaterialId { get; set; }
        public int MaterialId { get; set; }
        public int LocalidadId { get; set; }

        public decimal Cantidad { get; set; }

    }
}