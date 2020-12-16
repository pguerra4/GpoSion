using System.ComponentModel.DataAnnotations;

namespace GpoSion.API.Models
{
    public class Parametro
    {
        [Key]
        public string Clave { get; set; }
        public string Valor { get; set; }

        public string Comentarios { get; set; }

    }
}