namespace GpoSion.API.Models
{
    public class MaterialNumeroParte
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public string NoParte { get; set; }
        public NumeroParte NumeroParte { get; set; }
    }
}