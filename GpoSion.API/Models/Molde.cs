using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Molde
    {

        public int Id { get; set; }

        [Column("Molde")]
        public string ClaveMolde { get; set; }

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int? UbicacionAreaId { get; set; }
        public Area Ubicacion { get; set; }

        public int? MaquinaMoldeadoraId { get; set; }
        public Moldeadora Maquina { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public Usuario ModificadoPor { get; set; }

    }
}