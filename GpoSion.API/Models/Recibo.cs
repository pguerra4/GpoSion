using System;
using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class Recibo
    {
        public int ReciboId { get; set; }
        public int NoRecibo { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? HoraEntrada { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Transportista { get; set; }
        public string FacturaAduanal { get; set; }
        public string PedimentoImportacion { get; set; }

        public bool IsComplete { get; set; }

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string Recibio { get; set; }

        public int? CreadoPorId { get; set; }
        public Usuario CreadoPor { get; set; }

        public ICollection<DetalleRecibo> Detalle { get; set; }


    }
}