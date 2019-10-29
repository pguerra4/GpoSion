using System.ComponentModel.DataAnnotations;

namespace GpoSion.API.Models
{
    public class NumeroParte
    {
        [Key]
        public string NoParte { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}