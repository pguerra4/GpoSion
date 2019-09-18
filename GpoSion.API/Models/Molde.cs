using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Molde
    {
        private Area ubicacion;

        public int Id { get; set; }

        [Column("Molde")]
        public string ClaveMolde { get; set; }
        public Cliente Cliente { get; set; }

        public Area Ubicacion { get; set; }

        public Moldeadora Maquina { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public Usuario ModificadoPor { get; set; }

    }
}