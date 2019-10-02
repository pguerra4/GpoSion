using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoMaterial
    {
        public int MovimientoMaterialId { get; set; }
        public DateTime Fecha { get; set; }

        public Material Material { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Cantidad { get; set; }

        public Area Origen { get; set; }
        public Area Destino { get; set; }

        public Usuario ModificadoPor { get; set; }

        public Recibo Recibo { get; set; }

        public int Viajero { get; set; }

    }
}